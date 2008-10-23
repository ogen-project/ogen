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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace OGen.NTier.UTs.distributedlayer.remoting.server {
	public abstract class RS0__server {
		public void Start() {
			#if NET_1_1
			//ChannelServices.RegisterChannel(new HttpChannel(8085));
			ChannelServices.RegisterChannel(new TcpChannel(8085));
			#else
			//ChannelServices.RegisterChannel(new HttpChannel(8085), false);
			ChannelServices.RegisterChannel(new TcpChannel(8085), false);
			#endif
			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof(RS_User),
				"OGen.NTier.UTs.distributedlayer.remoting.server.RS_User.remoting",
				//"OGen.NTier.UTs.distributedlayer.remoting.server.RS_User.soap",

				WellKnownObjectMode.Singleton
				//WellKnownObjectMode.SingleCall
			);
			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof(RS_Authentication),
				"OGen.NTier.UTs.distributedlayer.remoting.server.RS_Authentication.remoting",
				//"OGen.NTier.UTs.distributedlayer.remoting.server.RS_Authentication.soap",

				WellKnownObjectMode.Singleton
				//WellKnownObjectMode.SingleCall
			);
		}
	}
}