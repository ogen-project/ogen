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

using OGen.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.lib.crypt;
using OGen.NTier.Kick.lib.datalayer;
using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
//using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	[BOClassAttribute("BO_DIC_Dic", "")]
	public static class SBO_DIC_Dic {

		#region public static long insObject(...);
		public static long insObject(
			DBConnection dbConnection_in, 

			int idApplication_in,
			int sourceTableField_ref_in, 

			params OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in
		) {
			if (textLanguage_in.Length == 0) return -1L;

			#region SO_DIC_Text _text = ...;
			SO_DIC_Text _text = new SO_DIC_Text(
					-1,
					idApplication_in,
					sourceTableField_ref_in
				);
			if (idApplication_in <= 0) {
				_text.IFApplication_isNull = true;
			}
			if (sourceTableField_ref_in <= 0) {
				_text.SourceTableField_ref_isNull = true;
			} 
			#endregion

			long _idtext = DO_DIC_Text.insObject(
				_text,
				true, 

				dbConnection_in
			);

			updObject(
				dbConnection_in,

				_idtext,
				textLanguage_in
			);

			return _idtext;
		}
		#endregion
		#region public static void updObject(...);
		public static void updObject(
			DBConnection dbConnection_in,

			long idText_in,

			params OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in
		) {
			SO_DIC_TextLanguage _textlanguage;
			foreach (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage _text in textLanguage_in) {
				#region _textlanguage = ...;
				_textlanguage 
					= new SO_DIC_TextLanguage(
						idText_in,
						_text.IFLanguage,
						"",
						""
					);
				if (_text.Text.Length > 8000) {
					_textlanguage.Text = _text.Text;
					_textlanguage.CharVar8000_isNull = true;
				} else {
					_textlanguage.Text_isNull = true;
					_textlanguage.CharVar8000 = _text.Text;
				}
				#endregion
				DO_DIC_TextLanguage.setObject(
					_textlanguage,
					true, 

					dbConnection_in
				);
			}
		}
		#endregion
//		#region public static void delObject(...);
		public static void delObject(
			DBConnection dbConnection_in,

			long idText_in

		//) {
		//    delObject(
		//        dbConnection_in,

		//        idText_in,

		//        -1
		//    );
		//}

		//public static void delObject(
		//    DBConnection dbConnection_in,

		//    long idText_in,

		//    int sourceTableField_ref_in
		) {

			DO_DIC_TextLanguage.delRecord_byText(
				idText_in,

				dbConnection_in
			);
			DO_DIC_Text.delObject(
				idText_in, 

				dbConnection_in
			);
		}
//		#endregion

		#region public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(...);
		[BOMethodAttribute("getRecord_byApplication", true)]
		public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			out int[] errors_out
		) {
			SO_vDIC_ApplicationLanguage[]  _output = null;

			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return _output;
			}
			#endregion

			return DO_vDIC_ApplicationLanguage.getRecord_byApplication(
				_sessionuser.IDApplication,
				0,
				0,
				null
			);
		}
		#endregion
	}
}