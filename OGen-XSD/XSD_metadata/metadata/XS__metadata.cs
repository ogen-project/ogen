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
using System.Xml.Serialization;
using System.Collections;

namespace OGen.XSD.lib.metadata.metadata {
	[System.Xml.Serialization.XmlRootAttribute("metadata")]
	#if NET_1_1
	public class XS__metadata : XS0__metadata {
	#else
	public partial class XS__metadata {
	#endif

		#region public string CaseTranslate(string word_in);
		private Hashtable casetranslate_cache_;

		public string CaseTranslate(
			string word_in, 
			string schemaName_in
		) {
			string _key = word_in + "|" + schemaName_in;

			if (casetranslate_cache_ == null) {
				casetranslate_cache_ = new Hashtable();
			}
			if (casetranslate_cache_.Contains(_key)) {
				return (string)casetranslate_cache_[_key];
			} else {
				#region XS_specificCaseType _case = ...;
				XS_specificCaseType _case;
				if (
					// (no schema provided)
					(schemaName_in == string.Empty)
					||
					(
						// (not found at specific schema)
						(_case = MetadataIndexCollection[schemaName_in].SpecificCaseCollection[word_in])
						==
						null
					)
				) {
					// look in generic
					_case = SpecificCaseCollection[word_in];
				}
				#endregion

				string _output = (_case == null) 
					? string.Empty 
					: _case.Translation;
				if (_output != string.Empty) {
					casetranslate_cache_.Add(_key, _output);
					return _output;
				} else {
					switch (CaseType) {
						case XS_CaseTypeEnumeration.PascalCase:
							if (word_in.Length > 0) {
								_output
									= word_in[0].ToString().ToUpper()
									+ word_in.Substring(1);
							} else {
								_output = word_in;
							}
							casetranslate_cache_.Add(_key, _output);
							return _output;
						case XS_CaseTypeEnumeration.camelCase:
						case XS_CaseTypeEnumeration.lowercase:
						case XS_CaseTypeEnumeration.UPPERCASE:
						case XS_CaseTypeEnumeration._invalid_:
							// ToDos: later!
							throw new Exception("not implemented!");
						case XS_CaseTypeEnumeration.none:
						default:
							casetranslate_cache_.Add(_key, word_in);
							return word_in;
					}
				}
			}
		}
		#endregion
	}
}
