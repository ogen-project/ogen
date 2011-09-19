#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace OGen.lib.crypt {
	public static class utils {
		public static class Server {
			#region static Server();
			static Server() {
				Server__setup();
			}

			public static void Server__setup() {
				RSAParameters _rsaparameters;

				if (
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"] != null)
					&&
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"] != "")
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"])
				) {
					RSA_Server_private = OGen.lib.crypt.utils.LoadRSAFile(
						System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Private"]
					);
				} else {
					RSA_Server_private = null;
				}

				if (
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"] != null)
					&&
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"] != "")
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"])
				) {
					RSA_Server_public = OGen.lib.crypt.utils.LoadRSAFile(
						System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Server_Public"]
					);
				} else {
					RSA_Server_public = null;
				}

				if (
					(RSA_Server_private == null)
					||
					(RSA_Server_public == null)
				) {
					return;
				}

				_rsaparameters = RSA_Server_public.ExportParameters(false);
				rsa_server_public_parameters_exponent_ = StringHelper.BytesToHexString(_rsaparameters.Exponent);
				rsa_server_public_parameters_modulus_ = StringHelper.BytesToHexString(_rsaparameters.Modulus);
			} 
			#endregion

			private static RSACryptoServiceProvider RSA_Server_private;

			private static RSACryptoServiceProvider RSA_Server_public;

			#region public static string RSA_Server_public_parameters_exponent { get; }
			private static string rsa_server_public_parameters_exponent_;
			public static string RSA_Server_public_parameters_exponent {
				get {
					if (
						(RSA_Server_private == null)
						||
						(RSA_Server_public == null)
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
						(RSA_Server_private == null)
						||
						(RSA_Server_public == null)
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
					(RSA_Server_private == null)
					||
					(RSA_Server_public == null)
				) {
					Server__setup();
				}

				return RSA_Server_private.Decrypt(
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
					(RSA_Server_private == null)
					||
					(RSA_Server_public == null)
				) {
					Server__setup();
				}

				return RSA_Server_public.Encrypt(
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
			//    return RSA_Server_private.Encrypt(
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
			//    return RSA_Server_public.Decrypt(
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
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"] != null)
					&&
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"] != "")
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"])
				) {
					try {
						RSA_Client_private = OGen.lib.crypt.utils.LoadRSAFile(
							System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"]
						);
					} catch (Exception _ex) {
#if DEBUG
						message_out.Add(_ex.Message);
#endif
						RSA_Client_private = null;
					}
				} else {
					RSA_Client_private = null;
				}
#if DEBUG
				message_out.Add(((RSA_Client_private == null) ? "null" : "OK") + ":" + System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Private"]);
#endif

				if (
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"] != null)
					&&
					(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"] != "")
					//&&
					//File.Exists(System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"])
				) {
					try {
						RSA_Client_public = OGen.lib.crypt.utils.LoadRSAFile(
							System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"]
						);
					} catch (Exception _ex) {
#if DEBUG
						message_out.Add(_ex.Message);
#endif
						RSA_Client_public = null;
					}
				} else {
					RSA_Client_public = null;
				}
#if DEBUG
				message_out.Add(((RSA_Client_public == null) ? "null" : "OK") + ":" + System.Configuration.ConfigurationManager.AppSettings["RSAKeys_Client_Public"]);
#endif

				if (
					(RSA_Client_private == null)
					||
					(RSA_Client_public == null)
				) {
					return;
				}

				_rsaparameters = RSA_Client_public.ExportParameters(false);
				rsa_client_public_parameters_exponent_ = StringHelper.BytesToHexString(_rsaparameters.Exponent);
				rsa_client_public_parameters_modulus_ = StringHelper.BytesToHexString(_rsaparameters.Modulus);
			} 
			#endregion

			private static RSACryptoServiceProvider RSA_Client_private;

			private static RSACryptoServiceProvider RSA_Client_public;
			#region public static string RSA_Client_public_parameters_exponent { get; }
			private static string rsa_client_public_parameters_exponent_;

			public static string RSA_Client_public_parameters_exponent {
				get {
					if (
						(RSA_Client_private == null)
						||
						(RSA_Client_public == null)
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
						(RSA_Client_private == null)
						||
						(RSA_Client_public == null)
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
					(RSA_Client_private == null)
					||
					(RSA_Client_public == null)
				) {
					Client__setup();
				}

				return RSA_Client_private.Decrypt(
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
					(RSA_Client_private == null)
					||
					(RSA_Client_public == null)
				) {
					Client__setup();
				}

				return RSA_Client_public.Encrypt(
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