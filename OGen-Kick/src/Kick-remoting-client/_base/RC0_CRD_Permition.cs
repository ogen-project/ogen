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
using System.Runtime.Remoting;

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.client {
	/// <summary>
	/// CRD_Permition remoting client.
	/// </summary>
	public class RC_CRD_Permition : 
		IBO_CRD_Permition 
	{
		static RC_CRD_Permition() {
			ReConfig();
		}

		#region private Fields...
		private static IBO_CRD_Permition bo_;
		#endregion
		#region public static void ReConfig();
		public static void ReConfig() {
			utils.Config.ReConfig();

			bo_ = new OGen.NTier.Kick.lib.distributedlayer.remoting.server.RS_CRD_Permition();
		}
		#endregion

		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Permition[] getRecord_all(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Permition[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			bool allProfiles_notJustApplication_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return bo_.getRecord_all(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				allProfiles_notJustApplication_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
	}
}