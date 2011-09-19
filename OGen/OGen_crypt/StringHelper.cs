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
	public class StringHelper {
		public static byte[] HexStringToBytes(string hex_in) {
			if (hex_in.Length == 0) {
				return new byte[] { 0 };
			}

			if (hex_in.Length % 2 == 1) {
				hex_in = "0" + hex_in;
			}

			byte[] _result = new byte[hex_in.Length / 2];

			for (int i = 0; i < hex_in.Length / 2; i++) {
				_result[i] = byte.Parse(
					hex_in.Substring(2 * i, 2), 
					System.Globalization.NumberStyles.AllowHexSpecifier
				);
			}

			return _result;
		}

		public static string BytesToHexString(byte[] input_in) {
			StringBuilder _hexString = new StringBuilder(64);

			for (int i = 0; i < input_in.Length; i++) {
				_hexString.Append(String.Format("{0:X2}", input_in[i]));
			}
			return _hexString.ToString();
		}

		public static string BytesToDecString(byte[] input_in) {
			StringBuilder _decString = new StringBuilder(64);

			for (int i = 0; i < input_in.Length; i++) {
				_decString.Append(String.Format(i == 0 ? "{0:D3}" : "-{0:D3}", input_in[i]));
			}
			return _decString.ToString();
		}

		// Bytes are string
		public static string ASCIIBytesToString(byte[] input_in) {
			System.Text.ASCIIEncoding _enc = new ASCIIEncoding();
			return _enc.GetString(input_in);
		}
		public static string UTF16BytesToString(byte[] input_in) {
			System.Text.UnicodeEncoding _enc = new UnicodeEncoding();
			return _enc.GetString(input_in);
		}
		public static string UTF8BytesToString(byte[] input_in) {
			System.Text.UTF8Encoding _enc = new UTF8Encoding();
			return _enc.GetString(input_in);
		}

		// Base64
		public static string ToBase64(byte[] input_in) {
			return Convert.ToBase64String(input_in);
		}

		public static byte[] FromBase64(string base64_in) {
			return Convert.FromBase64String(base64_in);
		}
	}
}