#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.businesslayer.shared.instances {
	using System;
	using System.Collections.Generic;
	using System.Text;

	#if BUSINESSOBJECT
	using OGen.NTier.Kick.lib.businesslayer;
	#endif
	using OGen.NTier.Kick.lib.businesslayer.shared;
	#if REMOTINGCLIENT
	using OGen.NTier.Kick.lib.distributedlayer.remoting.client;
	#endif
	#if WEBSERVICESCLIENT
	using OGen.NTier.Kick.lib.distributedlayer.webservices.client;
	#endif

#if NET_1_1
	public class CRD_Permition { private CRD_Permition() { }
#else
	public static class CRD_Permition {
#endif

#if BUSINESSOBJECT && REMOTINGCLIENT && WEBSERVICESCLIENT
		public static IBO_CRD_Permition BusinessObject = new BO_CRD_Permition();
		public static IBO_CRD_Permition RemotingClient = new RC_CRD_Permition();
		public static IBO_CRD_Permition WebserviceClient = new WC_CRD_Permition();
#else
		public static IBO_CRD_Permition InstanceClient
#if BUSINESSOBJECT
			= new BO_CRD_Permition();
#endif
#if REMOTINGCLIENT
			= new RC_CRD_Permition();
#endif
#if WEBSERVICESCLIENT
			= new WC_CRD_Permition();
#endif
#endif

		public static void ReConfig() {
#if BUSINESSOBJECT && REMOTINGCLIENT && WEBSERVICESCLIENT
			RC_CRD_Permition.ReConfig();
			((WC_CRD_Permition)WebserviceClient).ReConfig();
#else
#if REMOTINGCLIENT
			RC_CRD_Permition.ReConfig();
#endif
#if WEBSERVICESCLIENT
			((WC_CRD_Permition)InstanceClient).ReConfig();
#endif
#endif
		}
	}
}