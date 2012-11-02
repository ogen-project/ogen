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
	public class CRD_Profile { private CRD_Profile() { }
#else
	public static class CRD_Profile {
#endif

#if BUSINESSOBJECT && REMOTINGCLIENT && WEBSERVICESCLIENT
		public static IBO_CRD_Profile BusinessObject = new BO_CRD_Profile();
		public static IBO_CRD_Profile RemotingClient = new RC_CRD_Profile();
		public static IBO_CRD_Profile WebserviceClient = new WC_CRD_Profile();
#else
		public static IBO_CRD_Profile InstanceClient
#if BUSINESSOBJECT
			= new BO_CRD_Profile();
#endif
#if REMOTINGCLIENT
			= new RC_CRD_Profile();
#endif
#if WEBSERVICESCLIENT
			= new WC_CRD_Profile();
#endif
#endif

		public static void ReConfig() {
#if BUSINESSOBJECT && REMOTINGCLIENT && WEBSERVICESCLIENT
			RC_CRD_Profile.ReConfig();
			((WC_CRD_Profile)WebserviceClient).ReConfig();
#else
#if REMOTINGCLIENT
			RC_CRD_Profile.ReConfig();
#endif
#if WEBSERVICESCLIENT
			((WC_CRD_Profile)InstanceClient).ReConfig();
#endif
#endif
		}
	}
}