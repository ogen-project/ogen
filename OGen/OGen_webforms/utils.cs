#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Web;
using System.IO;
using System.Net;
using System.Collections;

namespace OGen.lib.presentationlayer.webforms {
	public class utils { private utils() {}

		#region public static string ConcatenateURLParams(Hashtable parameters_in);
		public static string ConcatenateURLParams(Hashtable parameters_in) {
			return ConcatenateURLParams(parameters_in, false);
		}
		public static string ConcatenateURLParams(Hashtable parameters_in, bool addQuestionmarkSeparator_in) {
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

		#region public static string ReadURL(...) { ... }
		public static string ReadURL(
			string url_in, 
			Hashtable parameters_in
		) {
			return ReadURL(
				url_in 
				+ ConcatenateURLParams(parameters_in, true)
			);
		}
		public static string ReadURL(
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

			StreamReader streamreader = new StreamReader(webresponse.GetResponseStream());
			return streamreader.ReadToEnd();
		}
		#endregion
	}
}