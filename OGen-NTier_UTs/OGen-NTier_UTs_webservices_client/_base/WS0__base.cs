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
using System.Web.Services;
using System.Web.Services.Protocols;

namespace OGen.NTier.UTs.lib.distributedlayer.webservices.client {
	public abstract class WS__base : SoapHttpClientProtocol {
		#region public WS__base(...);
		public WS__base(
			string url_in
		) {
			this.Url = url_in;

			if (this.IsLocalFileSystemWebService(this.Url)) {
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			} else {
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}
		#endregion

		protected bool useDefaultCredentialsSetExplicitly;

		#region public new string Url { get; set; }
		public new string Url {
			get {
				return base.Url;
			}
			set {
				if (
					(this.IsLocalFileSystemWebService(base.Url) == true)
					&&
					(this.useDefaultCredentialsSetExplicitly == false)
					&&
					(this.IsLocalFileSystemWebService(value) == false)
				) {
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}
		#endregion
		#region public new bool UseDefaultCredentials { get; set; }
		public new bool UseDefaultCredentials {
			get {
				return base.UseDefaultCredentials;
			}
			set {
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}
		#endregion

		#region public new void CancelAsync(object userState);
		/// <remarks/>
		public new void CancelAsync(object userState) {
			base.CancelAsync(userState);
		}
		#endregion
		#region protected bool IsLocalFileSystemWebService(string url);
		protected bool IsLocalFileSystemWebService(string url) {
			if (
				(url == null)
				||
				(url == string.Empty)
			) {
				return false;
			}
			System.Uri wsUri = new System.Uri(url);
			if (
				(wsUri.Port >= 1024)
				&&
				(
					string.Compare(
						wsUri.Host,
						"localHost",
						System.StringComparison.OrdinalIgnoreCase
					) == 0
				)
			) {
				return true;
			}
			return false;
		}
		#endregion
	}
}
