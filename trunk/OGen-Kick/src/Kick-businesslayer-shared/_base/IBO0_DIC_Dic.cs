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

using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer.shared {
	public interface IBO0_DIC_Dic {
		void delLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_byLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_Language(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		);
		void insLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] languageName_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] existingLanguagesInNewLanguage_in, 
			out System.Int32[] errors_out
		);
		void setSupportedLanguages(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			System.Int32[] idLanguages_in, 
			out System.Int32[] errors_out
		);
		void updLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in, 
			out System.Int32[] errors_out
		);
	}
}