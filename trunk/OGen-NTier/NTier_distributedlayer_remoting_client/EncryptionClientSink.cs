#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DistributedLayer.Remoting.Client {
	using System;
	using System.Collections;
	using System.IO;
	using System.Runtime.Remoting.Channels;
	using System.Runtime.Remoting.Messaging;

	using OGen.NTier.Libraries.DistributedLayer.Remoting;

	public class EncryptionClientSink : 
		BaseChannelSinkWithProperties, 
		IClientChannelSink
	{
		#region public RS_EncryptionClientSink(...);
		public EncryptionClientSink(
			IClientChannelSink nextChannelSink_in, 
			string keysPath_in, 
			string clientID_in
		) {
			this.nextchannelsink_ = nextChannelSink_in;
			this.keyspath_ = keysPath_in;
			this.clientid_ = clientID_in;
		} 
		#endregion

		#region public IClientChannelSink NextChannelSink { get; }
		private IClientChannelSink nextchannelsink_;

		public IClientChannelSink NextChannelSink {
			get { return this.nextchannelsink_; }
		} 
		#endregion


		#region private static bool isHeaderEncrypted(ITransportHeaders headers_in);
		private static bool isHeaderEncrypted(ITransportHeaders headers_in) {
			return (
				(headers_in[EncryptionHelper.X_ENCRYPT] != null)
				&&
				((string)headers_in[EncryptionHelper.X_ENCRYPT] == "1")
			);
		} 
		#endregion
		private string keyspath_;
		private string clientid_;


		#region public void AsyncProcessRequest(...);
		public void AsyncProcessRequest(
			IClientChannelSinkStack sinkStack_in,
			IMessage msg_in,
			ITransportHeaders headers_in,
			Stream stream_in
		) {
			#region encrypt...
			headers_in[EncryptionHelper.X_ENCRYPT] = "1";
			headers_in[EncryptionHelper.X_CLIENTID] = this.clientid_;
			stream_in
				= EncryptionHelper.Encrypt(
					stream_in,
					false,
					this.keyspath_,
					this.clientid_
				); 
			#endregion

			sinkStack_in.Push(this, null);
			this.nextchannelsink_.AsyncProcessRequest(
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
			#region decrypt...
			if (isHeaderEncrypted(headers_in)) {
				stream_in
					= EncryptionHelper.Decrypt(
						stream_in,
						false,
						this.keyspath_,
						this.clientid_
					);
			} 
			#endregion

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
			return this.nextchannelsink_.GetRequestStream(
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
			#region encrypt...
			requestHeaders_in[EncryptionHelper.X_ENCRYPT] = "1";
			requestHeaders_in[EncryptionHelper.X_CLIENTID] = this.clientid_;
			requestStream_in
				= EncryptionHelper.Encrypt(
					requestStream_in,
					false,
					this.keyspath_,
					this.clientid_
				); 
			#endregion

			this.nextchannelsink_.ProcessMessage(
				msg_in,
				requestHeaders_in,
				requestStream_in,

				out responseHeaders_out,
				out responseStream_out
			);

			#region decrypt...
			if (isHeaderEncrypted(responseHeaders_out)) {
				responseStream_out
					= EncryptionHelper.Decrypt(
						responseStream_out,
						false,
						this.keyspath_,
						this.clientid_
					);
			} 
			#endregion
		} 
		#endregion
	}
}