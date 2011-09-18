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

namespace OGen.NTier.lib.distributedlayer.remoting.server {
	public class CompressionServerSink : 
		BaseChannelSinkWithProperties, 
		IServerChannelSink
	{
		#region public RS_CompressionServerSink(...);
		public CompressionServerSink(
			IServerChannelSink nextChannelSink_in,
			bool mustDo_in
		) {
#if DEBUG
			Console.WriteLine("initiating compression sink");
#endif

			mustdo_ = mustDo_in;
			nextchannelsink_ = nextChannelSink_in;
		} 
		#endregion

		#region public IServerChannelSink NextChannelSink { get; }
		private IServerChannelSink nextchannelsink_;

		public IServerChannelSink NextChannelSink {
			get { return nextchannelsink_; }
		} 
		#endregion


		#region private bool isHeaderCompressed_(ITransportHeaders headers_in);
		private bool isHeaderCompressed_(ITransportHeaders headers_in) {
			return (
				(headers_in[CompressionHelper.X_COMPRESS] != null)
				&&
				((string)headers_in[CompressionHelper.X_COMPRESS] == "1")
			);
		}
		#endregion
		private bool mustdo_;

		#region public void AsyncProcessResponse(...);
		public void AsyncProcessResponse(
			IServerResponseChannelSinkStack sinkStack_in, 
			object state_in,
			IMessage message_in, 
			ITransportHeaders headers_in, 
			Stream stream_in
		) {
#if DEBUG
			Console.WriteLine("compression sink: AsyncProcessResponse...");
#endif
			bool _hasBeenCompressed = (bool)state_in;

			if (_hasBeenCompressed) {
				#region compress...
				headers_in[CompressionHelper.X_COMPRESS] = "1";

				stream_in = CompressionHelper.GetCompressedStreamCopy(
					stream_in
				); 
				#endregion
			} else {
				if (mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-compressed communications not allowed!\n\n");
				}
			}

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
#if DEBUG
			Console.WriteLine("compression sink: GetResponseStream...");
#endif
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
#if DEBUG
			Console.WriteLine("compression sink: ProcessMessage...");
#endif
			bool _isCompressed = false;

			if (isHeaderCompressed_(requestHeaders_in)) {
				#region uncompress...
				requestStream_in
					= CompressionHelper.GetUncompressedStreamCopy(
						requestStream_in
					);
				_isCompressed = true; 
				#endregion
			} else {
				if (mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-compressed communications not allowed!\n\n");
				}
			}

			sinkStack_in.Push(
				this, 
				_isCompressed
			);

			ServerProcessing _output = nextchannelsink_.ProcessMessage(
				sinkStack_in,
				requestMsg_in,
				requestHeaders_in,
				requestStream_in,

				out responseMsg_out,
				out responseHeaders_out,
				out responseStream_out
			);

			if (_output == ServerProcessing.Complete) {
				if (_isCompressed) {
					#region compress...
					responseHeaders_out[CompressionHelper.X_COMPRESS] = "1";
					responseStream_out
						= CompressionHelper.GetCompressedStreamCopy(
							responseStream_out
						); 
					#endregion
				}
			} 
			//// previously checked!
			//else {
			//    if (mustdo_) {
			//        throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-compressed communications not allowed!\n\n");
			//    }
			//}

			return _output;
		} 
		#endregion
	}
}