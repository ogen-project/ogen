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
	/// WEB_DefaultProfile remoting server.
	/// </summary>
	public class RS_WEB_DefaultProfile : 
		MarshalByRefObject, 
		IBO_WEB_DefaultProfile 
	{
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_Profile[] getRecord_all(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_Profile[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_DefaultProfile.getRecord_all(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setObject(...);
		public void setObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			System.Int64[] idProfile_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_DefaultProfile.setObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
	}
}