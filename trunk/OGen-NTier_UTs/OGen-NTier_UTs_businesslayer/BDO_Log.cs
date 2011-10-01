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

using OGen.NTier.lib.businesslayer;
using OGen.NTier.UTs.lib.datalayer;
using OGen.NTier.UTs.lib.businesslayer.proxy;

namespace OGen.NTier.UTs.lib.businesslayer {
	/// <summary>
	/// Log BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_Log">DO_Log</see> for the Business Layer.
	/// </summary>
	//[BOClassAttribute("BDO_Log", "BDO")]
	public sealed 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#endif
		class BDO_Log :
#if !USE_PARTIAL_CLASSES || NET_1_1
			BDO0_Log//, 
#endif
			//IBO_Log
	{
		#region public BDO_Log(...);
		///
		public BDO_Log() {
		}
		#endregion

		#region private Properties...
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#endregion
	}
}
