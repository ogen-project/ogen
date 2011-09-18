#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace OGen.NTier.lib.distributedlayer.remoting.server {
	public class ClientIPAddressServerSink : 
		BaseChannelObjectWithProperties, 
		IServerChannelSink, 
		IChannelSinkBase 
	{
		#region	public ClientIPAdressServerSink(...);
		public ClientIPAddressServerSink(
			IServerChannelSink nextChannelSink_in
		) {
			nextchannelsink_ = nextChannelSink_in;
		}
		#endregion

		#region public IServerChannelSink NextChannelSink { get; }
		private IServerChannelSink nextchannelsink_;

		public IServerChannelSink NextChannelSink {
			get {
				return nextchannelsink_;
			}
		}
		#endregion

		#region public void AsyncProcessResponse(...);
		public void AsyncProcessResponse(
			IServerResponseChannelSinkStack sinkStack_in,
			object state_in,
			IMessage message_in,
			ITransportHeaders headers_in,
			Stream stream_in
		) {
			CallContext.SetData(
				"ClientIPAddress", 
				((IPAddress)headers_in[CommonTransportKeys.IPAddress]).ToString()
			);

			sinkStack_in.AsyncProcessResponse(
				message_in, 
				headers_in, 
				stream_in
			);
		}
		#endregion
		#region public Stream GetResponseStream(...);
		public Stream GetResponseStream(
			IServerResponseChannelSinkStack sinkStack_in,
			object state_in,
			IMessage msg_in,
			ITransportHeaders headers_in
		) {
			return null;
		}
		#endregion
		#region public ServerProcessing ProcessMessage(...);
		public ServerProcessing ProcessMessage(
			IServerChannelSinkStack sinkStack_in,
			IMessage requestMsg_in,
			ITransportHeaders requestHeaders_in,
			Stream requestStream_in,

			out IMessage responseMsg_out,
			out ITransportHeaders responseHeaders_out,
			out Stream responseStream_out
		) {
			if (nextchannelsink_ != null) {
				CallContext.SetData(
					"ClientIPAddress", 
					((IPAddress)requestHeaders_in[CommonTransportKeys.IPAddress]).ToString()
				);
				ServerProcessing _serverprocessing = NextChannelSink.ProcessMessage(
					sinkStack_in,
					requestMsg_in,
					requestHeaders_in,
					requestStream_in,

					out responseMsg_out,
					out responseHeaders_out,
					out responseStream_out
				);
				return _serverprocessing;
			} else {
				responseMsg_out = null;
				responseHeaders_out = null;
				responseStream_out = null;
				return new ServerProcessing();
			}
		}
		#endregion
	}
}