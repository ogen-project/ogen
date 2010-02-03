#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OGen.NTier.lib.distributedlayer.remoting {
	public class EncryptionHelper {
		static EncryptionHelper() {
			client_rsakeys = new Dictionary<string, RSACryptoServiceProvider[]>();
		}
		private static RSACryptoServiceProvider serverprivate_rsa;
		private static RSACryptoServiceProvider serverpublic_rsa;
		private static Dictionary<string, RSACryptoServiceProvider[]> client_rsakeys;

		public const string X_ENCRYPT = "X-Encrypt";
		public const string X_CLIENTID = "X-ClientID";

		#region private static RSACryptoServiceProvider getRSA_forXMLFile(string filepath_in);
		private static RSACryptoServiceProvider getRSA_forXMLFile(string filepath_in) {
			CspParameters _cspParams = new CspParameters();
			_cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

			RSACryptoServiceProvider _output = new RSACryptoServiceProvider(_cspParams);

			System.IO.StreamReader _reader = new StreamReader(filepath_in);
			string _data = _reader.ReadToEnd();
			_output.FromXmlString(_data);

			return _output;
		} 
		#endregion
		#region private static void getRSA_forClient(...);
		private static void getRSA_forClient(
			string keysPath_in, 
			string clientID_in
		) {
			if (!client_rsakeys.ContainsKey(clientID_in)) {
				string _clientprivate_keyfile
					= System.IO.Path.Combine(
						keysPath_in, 
						string.Format(
							"ClientRSAKey.{0}.private.xml",
							clientID_in
						)
					);
				string _clientpublic_keyfile
					= System.IO.Path.Combine(
						keysPath_in, 
						string.Format(
							"ClientRSAKey.{0}.public.xml",
							clientID_in
						)
					);
				client_rsakeys.Add(
					clientID_in,
					new RSACryptoServiceProvider[] {
							File.Exists(_clientprivate_keyfile) 
								? getRSA_forXMLFile(_clientprivate_keyfile) 
								: null, 
							File.Exists(_clientpublic_keyfile) 
								? getRSA_forXMLFile(_clientpublic_keyfile) 
								: null
						}
				);
			}
		} 
		#endregion

		#region public static Stream Encrypt(...);
		public static Stream Encrypt(
			Stream stream_in,
			bool isServer_in,
			string keysPath_in,
			string clientID_in
		) {
#if DEBUG
Console.WriteLine("encrypting...");
#endif

			if (!isServer_in && (serverpublic_rsa == null)) {
				serverpublic_rsa
					= getRSA_forXMLFile(System.IO.Path.Combine(
						keysPath_in,
						"ServerRSAKey.public.xml"
					));
			}

			RSACryptoServiceProvider _clientpublic_rsa = null;
			if (isServer_in) {
				getRSA_forClient(
					keysPath_in,
					clientID_in
				);
				_clientpublic_rsa
					= client_rsakeys[clientID_in][1];

				if (_clientpublic_rsa == null) {
					System.Threading.Thread.Sleep(5 * 1000);
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n");
				}
			}

			MemoryStream _output_stream = new MemoryStream();
			byte[] _buf = new byte[117];
			byte[] _buf_REAL_SIZE;
			byte[] _enc;
			int _count;
#if DEBUG
int _total = 0;
#endif
			while ((_count = stream_in.Read(_buf, 0, 117)) > 0) {
#if DEBUG
_total += _count;
#endif
				_buf_REAL_SIZE = new byte[_count];
				for (int i = 0; i < _count; i++) {
					_buf_REAL_SIZE[i] = _buf[i];
				}

				_output_stream.Write(
					_enc = (isServer_in)
						? _clientpublic_rsa.Encrypt(_buf_REAL_SIZE, false)
						: serverpublic_rsa.Encrypt(_buf_REAL_SIZE, false),
					0,
					_enc.Length
				);
			}
			_output_stream.Flush();
			_output_stream.Seek(0, SeekOrigin.Begin);

#if DEBUG
Console.WriteLine("encrypt: size before: {0}", _total);
Console.WriteLine("encrypt: size after: {0}", _output_stream.Length);
#endif

			return _output_stream;
		} 
		#endregion
		#region public static Stream Decrypt(...);
		public static Stream Decrypt(
			Stream stream_in,
			bool isServer_in,
			string keysPath_in,
			string clientID_in
		) {
#if DEBUG
Console.WriteLine("decrypting...");
#endif

			if (isServer_in && (serverprivate_rsa == null)) {
				serverprivate_rsa
					= getRSA_forXMLFile(System.IO.Path.Combine(
						keysPath_in,
						"ServerRSAKey.private.xml"
					));
			}

			RSACryptoServiceProvider _clientprivate_rsa = null;
			if (!isServer_in) {
				getRSA_forClient(
					keysPath_in,
					clientID_in
				);
				_clientprivate_rsa
					= client_rsakeys[clientID_in][0];

				if (_clientprivate_rsa == null) {
					throw new Exception(string.Format(
						"can't find keys (key path: {0}; client id: {1}",
						keysPath_in,
						clientID_in
					));
				}
			}

			MemoryStream _output_stream = new MemoryStream();
			byte[] _buf = new byte[128];
			byte[] _dec;
			int _count;
#if DEBUG
int _total = 0;
#endif
			while ((_count = stream_in.Read(_buf, 0, 128)) > 0) {
#if DEBUG
_total += _count;
#endif
				_output_stream.Write(
					_dec = (isServer_in)
						? serverprivate_rsa.Decrypt(_buf, false)
						: _clientprivate_rsa.Decrypt(_buf, false),
					0,
					_dec.Length
				);
			}
			_output_stream.Flush();
			_output_stream.Seek(0, SeekOrigin.Begin);

#if DEBUG
Console.WriteLine("decrypt: size before: {0}", _total);
Console.WriteLine("decrypt: size after: {0}", _output_stream.Length);
#endif

			return _output_stream;
		} 
		#endregion
	}
}