#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer.Shared {
	using System;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;

#if NET_1_1
	public interface IBO0_LOG_Log {
#else
	public partial interface IBO_LOG_Log {
#endif
		OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_LOG_Log[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int IDLogtype_search_in, 
			long IDUser_search_in, 
			int IDErrortype_search_in, 
			System.DateTime Stamp_begin_search_in, 
			System.DateTime Stamp_end_search_in, 
			bool Read_search_in, 
			bool Read_search_isNull_in, 
			int idApplication_in, 
			bool idApplication_isNull_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		);
		void Log(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int logtype_in, 
			int errortype_in, 
			long idPermission_in, 
			int idApplication_in, 
			string format_in, 
			string[] args_in
		);
		void MarkRead(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLog_in, 
			out int[] errors_out
		);
	}
}