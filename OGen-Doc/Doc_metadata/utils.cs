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
using System.Text.RegularExpressions;
using OGen.Doc.lib.metadata.documentation;

namespace OGen.Doc.lib.metadata {
	public class utils { private utils() {}

		private static Regex fields_reg = new Regex(
			"^(?<before>.*)\\${(?<command>.*)::(?<params>.*)}(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);

		public static string translate(
			string text_in, 
			XS__documentation root_in
			//DocMetadata root_in
		) {
			string translate_out = text_in;
			string _translation;
			Match _matchingfields;

			while ((
				_matchingfields = fields_reg.Match(translate_out)
			).Success) {
				switch (_matchingfields.Groups["command"].Value.ToLower()) {
					case "config": {
						_translation 
							= root_in.Configs.ConfigCollection[
								_matchingfields.Groups["params"].Value
							].Value;
						
						break;
					}
					case "code": {
						_translation 
							= "<div class='code'><pre>"
							+ root_in.CodeSamples.CodeSampleCollection[
								_matchingfields.Groups["params"].Value
							].Code
							+ "</pre></div>";
						
						break;
					}
					case "link-external": {
						XS_linkType _link = root_in.Links.LinkCollection[
							_matchingfields.Groups["params"].Value
						];
						_translation = string.Format(
							"<a href='{0}'>{1}</a>", 
							_link.URL, 
							_link.Name
						);
						
						break;
					}
					default: {
						throw new Exception(string.Format(
							"unknown command: {0}", 
							_matchingfields.Groups["command"].Value
						));
					}
				}
				translate_out 
					= _matchingfields.Groups["before"].Value 
					+ _translation 
					+ _matchingfields.Groups["after"].Value
				;
			}

			return translate_out;


//			string translate_out = text_in;
//			int b, bb, be, e, eb, ee, m;
//
//			e = -1;
//			while ((b = translate_out.IndexOf("${", e + 1)) >= 0) {
//				be = b + 2;
//				bb = b - 1;
//
//				e = translate_out.IndexOf("}", be);
//				eb = e - 1;
//
//				m = translate_out.IndexOf(
//					"::", 
//					be, 
//					eb - be + 1
//				);
//
//				translate_out 
//					= (b != 0) ? translate_out.Substring(0, b - 1) : ""
//					+ "&lt;" + m + "&gt;"
//					+ translate_out.Substring(e + 1);
//			}
//
//			return translate_out;
		}
	}
}