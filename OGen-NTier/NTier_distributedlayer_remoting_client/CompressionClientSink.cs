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
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

using OGen.NTier.lib.distributedlayer.remoting;

namespace OGen.NTier.lib.distributedlayer.remoting.client {
	public class CompressionClientSink : 
		BaseChannelSinkWithProperties, 
		IClientChannelSink
	{
		#region public RS_CompressionClientSink(...);
		public CompressionClientSink(
			IClientChannelSink nextChannelSink_in
		) {
			nextchannelsink_ = nextChannelSink_in;
		} 
		#endregion

		#region public IClientChannelSink NextChannelSink { get; }
		private IClientChannelSink nextchannelsink_;

		public IClientChannelSink NextChannelSink {
			get { return nextchannelsink_; }
		} 
		#endregion


		private const string X_COMPRESS = "X-Compress";
		#region private bool isHeaderCompressed_(ITransportHeaders headers_in);
		private bool isHeaderCompressed_(ITransportHeaders headers_in) {
			return (
				(headers_in[X_COMPRESS] != null)
				&&
				((string)headers_in[X_COMPRESS] == "1")
			);
		} 
		#endregion


		#region public void AsyncProcessRequest(...);
		public void AsyncProcessRequest(
			IClientChannelSinkStack sinkStack_in,
			IMessage msg_in,
			ITransportHeaders headers_in,
			Stream stream_in
		) {
			// compress...
			headers_in[X_COMPRESS] = "1";
			stream_in
				= CompressionHelper.GetCompressedStreamCopy(
					stream_in
				);

			// push onto stack and forward the request
			sinkStack_in.Push(this, null);
			nextchannelsink_.AsyncProcessRequest(
				sinkStack_in,
				msg_in,
				headers_in,
				stream_in
			);
		} 
		#endregion
		#region public void AsyncProcessResponse(...);
		public void AsyncProcessResponse(
			IClientResponseChannelSinkStack sinkStack_in,
			object state_in,
			ITransportHeaders headers_in,
			Stream stream_in
		) {
			// uncompress...
			if (isHeaderCompressed_(headers_in)) {
				stream_in
					= CompressionHelper.GetUncompressedStreamCopy(
						stream_in
					);
			}

			// forward the request...
			sinkStack_in.AsyncProcessResponse(
				headers_in,
				stream_in
			);
		} 
		#endregion
		#region public Stream GetRequestStream(...);
		public Stream GetRequestStream(
			IMessage msg_in,
			ITransportHeaders headers_in
		) {
			return nextchannelsink_.GetRequestStream(
				msg_in,
				headers_in
			);
		} 
		#endregion
		#region public void ProcessMessage(...);
		public void ProcessMessage(
			IMessage msg_in,
			ITransportHeaders requestHeaders_in,
			Stream requestStream_in,

			out ITransportHeaders responseHeaders_out,
			out Stream responseStream_out
		) {
			// compress...
			requestHeaders_in[X_COMPRESS] = "1";
			requestStream_in
				= CompressionHelper.GetCompressedStreamCopy(
					requestStream_in
				);

			// forward the call to the next sink
			nextchannelsink_.ProcessMessage(
				msg_in,
				requestHeaders_in,
				requestStream_in,

				out responseHeaders_out,
				out responseStream_out
			);

			// uncompress...
			if (isHeaderCompressed_(responseHeaders_out)) {
				responseStream_out
					= CompressionHelper.GetUncompressedStreamCopy(
						responseStream_out
					);
			}
		} 
		#endregion
	}
}