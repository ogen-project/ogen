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

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.server {
	/// <summary>
	/// FOR_Forum remoting server.
	/// </summary>
	public class RS_FOR_Forum : 
		MarshalByRefObject, 
		IBO_FOR_Forum 
	{
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message getObject(
			string credentials_in, 
			long idMessage_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_FOR_Forum.getObject(
				credentials_in, 
				idMessage_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message[] getRecord_byParent(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message[] getRecord_byParent(
			string credentials_in, 
			long idMessage__parent_in, 
			bool isRecursive_orThread_notReplies_in, 
			int page_in, 
			int page_numRecords_in, 
			out long count_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_FOR_Forum.getRecord_byParent(
				credentials_in, 
				idMessage__parent_in, 
				isRecursive_orThread_notReplies_in, 
				page_in, 
				page_numRecords_in, 
				out count_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message[] getRecord_Forum(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vFOR_Message[] getRecord_Forum(
			string credentials_in, 
			long idApplication_in, 
			out long idMessage__forum_out, 
			int page_in, 
			int page_numRecords_in, 
			out long count_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_FOR_Forum.getRecord_Forum(
				credentials_in, 
				idApplication_in, 
				out idMessage__forum_out, 
				page_in, 
				page_numRecords_in, 
				out count_out, 
				out errors_out
			);
		}
		#endregion
		#region public long insObject(...);
		public long insObject(
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_FOR_Message message_in, 
			int idApplication_in, 
			bool selectIdentity_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_FOR_Forum.insObject(
				credentials_in, 
				message_in, 
				idApplication_in, 
				selectIdentity_in, 
				out errors_out
			);
		}
		#endregion
	}
}