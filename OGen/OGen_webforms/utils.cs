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
using System.Web;
using System.IO;
using System.Net;
using System.Collections;

namespace OGen.lib.presentationlayer.webforms {
	public
#if !NET_1_1
		static
#endif
		class utils { 
#if NET_1_1
		private utils() {}
#endif

		#region public static string ConcatenateURLParams(Hashtable parameters_in);
		public static string ConcatenateURLParams(
			Hashtable parameters_in
		) {
			return ConcatenateURLParams(parameters_in, false);
		}
		public static string ConcatenateURLParams(
			Hashtable parameters_in, 
			bool addQuestionmarkSeparator_in
		) {
			string ConcatenateURLParams_out = "";
			string _separator = (addQuestionmarkSeparator_in) ? "?" : "";

			IDictionaryEnumerator _denum = parameters_in.GetEnumerator();
			_denum.Reset();
			while (_denum.MoveNext()) {
				ConcatenateURLParams_out += string.Format(
					"{0}{1}={2}", 
					/*00*/(ConcatenateURLParams_out == "") ? _separator : "&", 
					/*01*/_denum.Key.ToString(), 
					/*02*/System.Web.HttpUtility.UrlEncode(
						_denum.Value.ToString()
					)
				);
			}

			return ConcatenateURLParams_out;
		}
		#endregion

		#region public static System.IO.Stream ReadURL(...) { ... }
		public static System.IO.Stream ReadURL(
			string url_in, 
			Hashtable parameters_in
		) {
			return ReadURL(
				url_in 
				+ ConcatenateURLParams(parameters_in, true)
			);
		}
		public static System.IO.Stream ReadURL(
			string url_in
		) {
			WebRequest webrequest = System.Net.HttpWebRequest.Create(url_in);
			WebResponse webresponse;
			try {
				webresponse = webrequest.GetResponse();
			} catch (Exception e) {
				throw new Exception(string.Format(
					"\n\n---\n{0}\n{1}\n---\n",
					//e.StackTrace
					e.Message,
					url_in
					//e.ToString()
					//webrequest.Headers.Keys[0].ToString()
				));
			}

			//webrequest.Credentials = new System.Net.WebRequest() .credentials Credentials

			return ((System.IO.Stream)webresponse.GetResponseStream());
		}
		#endregion
		#region public static string ReadURL_ToString(...) { ... }
//#if !(NET_1_0 || NET_1_1)
//        public static string ReadURL_ToString(
//            string url_in,
//            System.Collections.Generic.Dictionary<string, string> parameters_in
//        ) {
//            return ReadURL_ToString(
//                url_in
//                + ConcatenateURLParams(parameters_in, true)
//            );
//        }
//#endif
		public static string ReadURL_ToString(
			string url_in, 
			Hashtable parameters_in
		) {
			return ReadURL_ToString(
				url_in 
				+ ConcatenateURLParams(parameters_in, true)
			);
		}
		public static string ReadURL_ToString(
			string url_in
		) {
			StreamReader streamreader = new StreamReader(
				ReadURL(url_in)
			);
			return streamreader.ReadToEnd();
		}
		#endregion
	}
}
