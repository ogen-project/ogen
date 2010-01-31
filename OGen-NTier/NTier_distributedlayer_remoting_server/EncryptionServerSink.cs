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

namespace OGen.NTier.lib.distributedlayer.remoting.server {
	public class EncryptionServerSink : 
		BaseChannelSinkWithProperties, 
		IServerChannelSink
	{
		#region public RS_EncryptionServerSink(...);
		public EncryptionServerSink(
			IServerChannelSink nextChannelSink_in,
			string keysPath_in, 
			bool mustDo_in
		) {
#if DEBUG
			Console.WriteLine("initiating encryption sink");
#endif

			keyspath_ = keysPath_in;
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


		private const string X_ENCRYPT = "X-Encrypt";
		private const string X_CLIENTID = "X-ClientID";
		#region private bool isHeaderEncrypted(ITransportHeaders headers_in);
		private bool isHeaderEncrypted(ITransportHeaders headers_in) {
			return (
				(headers_in[X_ENCRYPT] != null)
				&&
				((string)headers_in[X_ENCRYPT] == "1")
			);
		}
		#endregion
		#region private struct StateStruct { ... }
		private struct StateStruct {
			public StateStruct(
				bool isEncripted_in,
				string ClientID_in
			) {
				isEncripted = isEncripted_in;
				ClientID = ClientID_in;
			}

			public bool isEncripted;
			public string ClientID;
		} 
		#endregion
		private string keyspath_;
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
			Console.WriteLine("encryption sink: AsyncProcessResponse");
#endif

			bool _hasBeenEncrypted 
				= (state_in != null) 
					? ((StateStruct)state_in).isEncripted
					: false
				;

			if (_hasBeenEncrypted) {
				// compress...
				headers_in[X_ENCRYPT] = "1";
				stream_in
					= EncryptionHelper.Encrypt(
						stream_in,
						true,
						keyspath_,
						((StateStruct)state_in).ClientID
					);
			} else {
				if (mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
				}
			}

			// forwarding to the stack for further processing...
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
			Console.WriteLine("encryption sink: GetResponseStream");
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
			Console.WriteLine("encryption sink: ProcessMessage");
#endif

			bool _isEncrypted = false;

			// uncompress...
			if (isHeaderEncrypted(requestHeaders_in)) {
				requestStream_in
					= EncryptionHelper.Decrypt(
						requestStream_in,
						true,
						keyspath_, 
						(string)requestHeaders_in[X_CLIENTID]
					);
				_isEncrypted = true;
			} else {
				if (mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
				}
			}

			// pushing onto stack and forwarding the call
			sinkStack_in.Push(
				this, 
				new StateStruct(
					_isEncrypted, 
					_isEncrypted ? (string)requestHeaders_in[X_CLIENTID] : ""
				)
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
				// compress...
				if (_isEncrypted) {
					responseHeaders_out[X_ENCRYPT] = "1";
					responseStream_out
						= EncryptionHelper.Encrypt(
							responseStream_out,
							true, 
							keyspath_, 
							(string)requestHeaders_in[X_CLIENTID]
						);
				} 
				//// previously checked!
				//else {
				//    if (mustdo_) {
				//        throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
				//    }
				//}
			}

			// returning status information
			return _output;
		} 
		#endregion
	}
}