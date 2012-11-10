#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DistributedLayer.Remoting.Server {
	using System;
	using System.Collections;
	using System.IO;
	using System.Runtime.Remoting.Channels;
	using System.Runtime.Remoting.Messaging;

	using OGen.NTier.Libraries.DistributedLayer.Remoting;

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

			this.keyspath_ = keysPath_in;
			this.mustdo_ = mustDo_in;
			this.nextchannelsink_ = nextChannelSink_in;
		} 
		#endregion

		#region public IServerChannelSink NextChannelSink { get; }
		private IServerChannelSink nextchannelsink_;

		public IServerChannelSink NextChannelSink {
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
		#region private struct StateStruct { ... }
#if NET_1_1
		private struct StateStruct {
#else
		private struct StateStruct : IEquatable<StateStruct> {
#endif
			public StateStruct(
				bool isEncripted_in,
				string ClientID_in
			) {
				this.isEncripted = isEncripted_in;
				this.ClientID = ClientID_in;
			}

			public bool isEncripted;
			public string ClientID;

#if NET_1_1
#else
			public override int GetHashCode() {
				int _output = 17;
				_output = (_output * 23) + this.isEncripted.GetHashCode();
				_output = (_output * 23) + this.ClientID.GetHashCode();
				return _output;
			}
			public bool Equals(StateStruct other) {
				return
					(other.isEncripted.Equals(this.isEncripted)) &&
					(other.ClientID.Equals(this.ClientID));
			}
			public override bool Equals(object obj) {
				if (!(obj is StateStruct))
					return false;

				return this.Equals((StateStruct)obj);
			}

			public static bool operator ==(StateStruct aux1, StateStruct aux2) {
				return aux1.Equals(aux2);
			}

			public static bool operator !=(StateStruct aux1, StateStruct aux2) {
				return !aux1.Equals(aux2);
			}
#endif
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
				#region encrypt...
				headers_in[EncryptionHelper.X_ENCRYPT] = "1";
				stream_in
					= EncryptionHelper.Encrypt(
						stream_in,
						true,
						this.keyspath_,
						((StateStruct)state_in).ClientID
					); 
				#endregion
			} else {
				if (this.mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
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

			if (isHeaderEncrypted(requestHeaders_in)) {
				#region decrypt...
				requestStream_in
					= EncryptionHelper.Decrypt(
						requestStream_in,
						true,
						this.keyspath_,
						(string)requestHeaders_in[EncryptionHelper.X_CLIENTID]
					);
				_isEncrypted = true; 
				#endregion
			} else {
				if (this.mustdo_) {
					throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
				}
			}

			sinkStack_in.Push(
				this, 
				new StateStruct(
					_isEncrypted, 
					_isEncrypted ? (string)requestHeaders_in[EncryptionHelper.X_CLIENTID] : ""
				)
			);

			ServerProcessing _output = this.nextchannelsink_.ProcessMessage(
				sinkStack_in,
				requestMsg_in,
				requestHeaders_in,
				requestStream_in,

				out responseMsg_out,
				out responseHeaders_out,
				out responseStream_out
			);

			if (_output == ServerProcessing.Complete) {
				if (_isEncrypted) {
					#region encrypt...
					responseHeaders_out[EncryptionHelper.X_ENCRYPT] = "1";
					responseStream_out
						= EncryptionHelper.Encrypt(
							responseStream_out,
							true,
							this.keyspath_,
							(string)requestHeaders_in[EncryptionHelper.X_CLIENTID]
						); 
					#endregion
				} 
				//// previously checked!
				//else {
				//    if (mustdo_) {
				//        throw new Exception("\n\n\t\tyour activity is being logged!\n\n\t\tun-encrypted communications not allowed!\n\n");
				//    }
				//}
			}

			return _output;
		} 
		#endregion
	}
}