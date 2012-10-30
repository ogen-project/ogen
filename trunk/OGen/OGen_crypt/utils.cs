#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.lib.crypt {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;

	public static class utils {
		public static class Server {
			#region static Server();
			static Server() {
				Server__setup();
			}

			public static void Server__setup() {
				RSAParameters _rsaparameters;

				if (
					!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"])
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"])
				) {
					rsa_server_private_ = OGen.lib.crypt.utils.LoadRSAFile(
						System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"]
					);
				} else {
					rsa_server_private_ = null;
				}

				if (
					!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"])
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"])
				) {
					rsa_server_public_ = OGen.lib.crypt.utils.LoadRSAFile(
						System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"]
					);
				} else {
					rsa_server_public_ = null;
				}

				if (
					(rsa_server_private_ == null)
					||
					(rsa_server_public_ == null)
				) {
					return;
				}

				_rsaparameters = rsa_server_public_.ExportParameters(false);
				rsa_server_public_parameters_exponent_ = StringHelper.BytesToHexString(_rsaparameters.Exponent);
				rsa_server_public_parameters_modulus_ = StringHelper.BytesToHexString(_rsaparameters.Modulus);
			} 
			#endregion

			private static RSACryptoServiceProvider rsa_server_private_;

			private static RSACryptoServiceProvider rsa_server_public_;

			#region public static string RSA_Server_public_parameters_exponent { get; }
			private static string rsa_server_public_parameters_exponent_;
			public static string RSA_Server_public_parameters_exponent {
				get {
					if (
						(rsa_server_private_ == null)
						||
						(rsa_server_public_ == null)
					) {
						Server__setup();
					}

					return rsa_server_public_parameters_exponent_;
				}
			}
			#endregion
			#region public static string RSA_Server_public_parameters_modulus { get; }
			private static string rsa_server_public_parameters_modulus_;
			public static string RSA_Server_public_parameters_modulus {
				get {
					if (
						(rsa_server_private_ == null)
						||
						(rsa_server_public_ == null)
					) {
						Server__setup();
					}

					return rsa_server_public_parameters_modulus_;
				}
			}
			#endregion

			#region public static string RSA_Server_private_Decrypt(...);
			public static string RSA_Server_private_Decrypt(
				string rgb
			) {
				return utils.bytes2string(
					RSA_Server_private_Decrypt(
						utils.string2bytes(
							rgb
						)
					)
				);
			}
			public static string RSA_Server_private_Decrypt64(
				string rgb
			) {
				//return OGen.lib.crypt.StringHelper.ASCIIBytesToString(
				//    OGen.lib.crypt.StringHelper.FromBase64(
				//        utils.bytes2string(
				//            RSA_Server_private_Decrypt(
				//                OGen.lib.crypt.StringHelper.HexStringToBytes(
				//                    rgb
				//                )
				//            )
				//        )
				//    )
				//);
				return utils.bytes2string(
					RSA_Server_private_Decrypt(
						OGen.lib.crypt.StringHelper.FromBase64(
							rgb
						)
					)
				);
			}
			public static byte[] RSA_Server_private_Decrypt(
				byte[] rgb
			) {
				if (
					(rsa_server_private_ == null)
					||
					(rsa_server_public_ == null)
				) {
					Server__setup();
				}

				return rsa_server_private_.Decrypt(
					rgb,
					false
				);
			} 
			#endregion
			#region public static string RSA_Server_public_Encrypt(...);
			public static string RSA_Server_public_Encrypt(
				string rgb
			) {
				return utils.bytes2string(
					RSA_Server_public_Encrypt(
						utils.string2bytes(
							rgb
						)
					)
				);
			}
			public static string RSA_Server_public_Encrypt64(
				string rgb
			) {
				//return OGen.lib.crypt.StringHelper.BytesToHexString(
				//    RSA_Server_public_Encrypt(
				//        string2bytes(
				//            OGen.lib.crypt.StringHelper.ToBase64(
				//                string2bytes(
				//                    rgb
				//                )
				//            )
				//        )
				//    )
				//);
				return OGen.lib.crypt.StringHelper.ToBase64(
					RSA_Server_public_Encrypt(
						string2bytes(
							rgb
						)
					)
				);
			}
			public static byte[] RSA_Server_public_Encrypt(
				byte[] rgb
			) {
				if (
					(rsa_server_private_ == null)
					||
					(rsa_server_public_ == null)
				) {
					Server__setup();
				}

				return rsa_server_public_.Encrypt(
					rgb,
					false
				);
			} 
			#endregion

			//public static string RSA_Server_private_Encrypt(
			//    string rgb
			//) {
			//    return utils.bytes2string(
			//        RSA_Server_private_Encrypt(
			//            utils.string2bytes(
			//                rgb
			//            )
			//        )
			//    );
			//}
			//public static byte[] RSA_Server_private_Encrypt(
			//    byte[] rgb
			//) {
			//    return rsa_server_private_.Encrypt(
			//        rgb,
			//        false
			//    );
			//}

			//public static string RSA_Server_public_Decrypt(
			//        string rgb
			//    ) {
			//    return utils.bytes2string(
			//        RSA_Server_public_Decrypt(
			//            utils.string2bytes(
			//                rgb
			//            )
			//        )
			//    );
			//}
			//public static byte[] RSA_Server_public_Decrypt(
			//    byte[] rgb
			//) {
			//    return rsa_server_public_.Decrypt(
			//        rgb,
			//        false
			//    );
			//} 
		}

		public static class Client {
			#region static Client();
			static Client() {
				Client__setup();
			}

			public static void Client__setup() {
#if DEBUG
				List<string> _message;

				Client__setup(
					out _message
				);
			}
			public static void Client__setup(
				out List<string> message_out
			) {
				message_out = new List<string>();
#endif

				RSAParameters _rsaparameters;

				if (
					!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"])
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"])
				) {
					try {
						rsa_client_private_ = OGen.lib.crypt.utils.LoadRSAFile(
							System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"]
						);
					} catch (Exception _ex) {
#if DEBUG
						message_out.Add(_ex.Message);
#endif
						rsa_client_private_ = null;
					}
				} else {
					rsa_client_private_ = null;
				}
#if DEBUG
				message_out.Add(((rsa_client_private_ == null) ? "null" : "OK") + ":" + System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"]);
#endif

				if (
					!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"])
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"])
				) {
					try {
						rsa_client_public_ = OGen.lib.crypt.utils.LoadRSAFile(
							System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"]
						);
					} catch (Exception _ex) {
#if DEBUG
						message_out.Add(_ex.Message);
#endif
						rsa_client_public_ = null;
					}
				} else {
					rsa_client_public_ = null;
				}
#if DEBUG
				message_out.Add(((rsa_client_public_ == null) ? "null" : "OK") + ":" + System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"]);
#endif

				if (
					(rsa_client_private_ == null)
					||
					(rsa_client_public_ == null)
				) {
					return;
				}

				_rsaparameters = rsa_client_public_.ExportParameters(false);
				rsa_client_public_parameters_exponent_ = StringHelper.BytesToHexString(_rsaparameters.Exponent);
				rsa_client_public_parameters_modulus_ = StringHelper.BytesToHexString(_rsaparameters.Modulus);
			} 
			#endregion

			private static RSACryptoServiceProvider rsa_client_private_;

			private static RSACryptoServiceProvider rsa_client_public_;
			#region public static string RSA_Client_public_parameters_exponent { get; }
			private static string rsa_client_public_parameters_exponent_;

			public static string RSA_Client_public_parameters_exponent {
				get {
					if (
						(rsa_client_private_ == null)
						||
						(rsa_client_public_ == null)
					) {
						Client__setup();
					}

					return rsa_client_public_parameters_exponent_;
				}
			}
			#endregion
			#region public static string RSA_Client_public_parameters_modulus { get; }
			private static string rsa_client_public_parameters_modulus_;

			public static string RSA_Client_public_parameters_modulus {
				get {
					if (
						(rsa_client_private_ == null)
						||
						(rsa_client_public_ == null)
					) {
						Client__setup();
					}

					return rsa_client_public_parameters_modulus_;
				}
			} 
			#endregion

			#region public static string RSA_Client_private_Decrypt(...);
			public static string RSA_Client_private_Decrypt(
				string rgb
			) {
				return utils.bytes2string(
					RSA_Client_private_Decrypt(
						utils.string2bytes(
							rgb
						)
					)
				);
			}
			public static string RSA_Client_private_Decrypt64(
				string rgb
			) {
				return OGen.lib.crypt.StringHelper.ASCIIBytesToString(
					OGen.lib.crypt.StringHelper.FromBase64(
						utils.bytes2string(
							RSA_Client_private_Decrypt(
								OGen.lib.crypt.StringHelper.HexStringToBytes(
									rgb
								)
							)
						)
					)
				);
			}
			public static byte[] RSA_Client_private_Decrypt(
				byte[] rgb
			) {
				if (
					(rsa_client_private_ == null)
					||
					(rsa_client_public_ == null)
				) {
					Client__setup();
				}

				return rsa_client_private_.Decrypt(
					rgb,
					false
				);
			} 
			#endregion
			#region public static string RSA_Client_public_Encrypt(...);
			public static string RSA_Client_public_Encrypt(
				string rgb
			) {
				return utils.bytes2string(
					RSA_Client_public_Encrypt(
						utils.string2bytes(
							rgb
						)
					)
				);
			}
			public static string RSA_Client_public_Encrypt64(
				string rgb
			) {
				return OGen.lib.crypt.StringHelper.BytesToHexString(
					RSA_Client_public_Encrypt(
						string2bytes(
							OGen.lib.crypt.StringHelper.ToBase64(
								string2bytes(
									rgb
								)
							)
						)
					)
				);
			}
			public static byte[] RSA_Client_public_Encrypt(
				byte[] rgb
			) {
				if (
					(rsa_client_private_ == null)
					||
					(rsa_client_public_ == null)
				) {
					Client__setup();
				}

				return rsa_client_public_.Encrypt(
					rgb,
					false
				);
			} 
			#endregion
		}

//		#region public static RSACryptoServiceProvider LoadRSAFile(...);
		public static RSACryptoServiceProvider LoadRSAFile(
			string path_private_in
		) {
			CspParameters _cspParams = new CspParameters();
			// To avoid repeated costly key pair generation
			// + if service running with no admin previleges this is a must (like maximumasp)
			_cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

			//if (Uri.IsWellFormedUriString(path_private_in, UriKind.Absolute)) {
			//} else if (System.IO.File.Exists(path_private_in)) {
			//}

			string _xml;
			Uri _uri = new Uri(path_private_in);
			if (_uri.IsFile) {
				_xml = new StreamReader(_uri.AbsolutePath).ReadToEnd();
			} else {
				System.Net.WebResponse _webresponse = System.Net.HttpWebRequest.Create(_uri).GetResponse();
				_xml = new StreamReader(
					(System.IO.Stream)_webresponse.GetResponseStream()
				).ReadToEnd();
			}

			RSACryptoServiceProvider _sp_private = new RSACryptoServiceProvider(
				_cspParams
			);
			_sp_private.FromXmlString(_xml);

			return _sp_private;
		} 
//		#endregion

		#region public static string bytes2string(...);
		public static string bytes2string(
			byte[] bytes_in
		) {
			StringBuilder _output = new StringBuilder();
			for (int i = 0; i < bytes_in.Length; i++) {
				_output.Append((char)bytes_in[i]);
			}
			return _output.ToString();
		} 
		#endregion
		#region public static byte[] string2bytes(...);
		public static byte[] string2bytes(
			string text_in
		) {
			byte[] _output = new byte[text_in.Length];
			for (int i = 0; i < text_in.Length; i++) {
				_output[i] = (byte)text_in[i];
			}
			return _output;
		} 
		#endregion
	}
}