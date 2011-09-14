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

using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	public class BO_LOG_Log :
		IBO_LOG_Log
	{
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_LOG_Log[] getRecord_generic(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_LOG_Log[] getRecord_generic(
			string credentials_in, 
			int IDLogtype_search_in, 
			long IDUser_search_in, 
			int IDErrortype_search_in, 
			System.DateTime Stamp_begin_search_in, 
			System.DateTime Stamp_end_search_in, 
			bool Read_search_in, 
			bool Read_search_isNull_in, 
			int idApplication_in, 
			bool idApplication_isNull_in, 
			int page_in, 
			int page_numRecords_in, 
			out int error_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.getRecord_generic(
				credentials_in, 
				IDLogtype_search_in, 
				IDUser_search_in, 
				IDErrortype_search_in, 
				Stamp_begin_search_in, 
				Stamp_end_search_in, 
				Read_search_in, 
				Read_search_isNull_in, 
				idApplication_in, 
				idApplication_isNull_in, 
				page_in, 
				page_numRecords_in, 
				out error_out
			);
		}
		#endregion
		#region public void Log(...);
		public void Log(
			string credentials_in, 
			int logtype_in, 
			int errortype_in, 
			int idApplication_in, 
			string format_in, 
			System.String[] args_in
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.Log(
				credentials_in, 
				logtype_in, 
				errortype_in, 
				idApplication_in, 
				format_in, 
				args_in
			);
		}
		#endregion
		#region public void MarkRead(...);
		public void MarkRead(
			string credentials_in, 
			int idLog_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.MarkRead(
				credentials_in, 
				idLog_in, 
				out errors_out
			);
		}
		#endregion
	}
}