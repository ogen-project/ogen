#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.lib.presentationlayer.winforms.Flowforms {
	using System;

	public abstract class cFlowform {
		#region public cFlowform(...);
		protected cFlowform(
			dNotifyBase notifyBase_in, 
			int numFlowformForms_in
		) {
			this.notifybase_ = notifyBase_in;
			this.myflowforms_ = new cFlowform[numFlowformForms_in];
		}
		public virtual void Dispose() {
			if (this.MyFlowforms != null) {
				for (int i = 0; i < this.MyFlowforms.Length; i++) {
					if (this.MyFlowforms[i] != null)
						this.MyFlowforms[i].Dispose();
					this.MyFlowforms[i] = null;
				}
			}

			this.myform_.Dispose();
		}
		#endregion

		#region Delegations...
		public delegate void dNotifyBase(eFlowformEvents someEvent_in, cFlowform flowform_in);
		private dNotifyBase notifybase_ = null;

		public void NotifyBase(eFlowformEvents someEvent_in, cFlowform flowform_in) {
			if (this.notifybase_ != null) {
				this.notifybase_(someEvent_in, flowform_in);
			} else {
				switch (someEvent_in) {
					case eFlowformEvents.Closed:
						this.Dispose();
						break;
					case eFlowformEvents.Back:
						// do nothing...
						break;
				}
			}
		}
		#endregion

		#region protected cFlowform[] MyFlowforms { get; }
		private cFlowform[] myflowforms_;
		protected cFlowform[] MyFlowforms {
			get { return this.myflowforms_; }
		}
		#endregion
		protected abstract System.Windows.Forms.Form myform_ { get; }

		protected void MyForm_notifiedMe(eFlowformFormEvents someEvent_in) {
			switch (someEvent_in) {
				case eFlowformFormEvents.Closed:
					this.NotifyBase(eFlowformEvents.Closed, this);
					break;
				case eFlowformFormEvents.Back:
					this.NotifyBase(eFlowformEvents.Back, this);
					break;
			}
		}
		protected void MyFlowforms_notifiedMe(eFlowformEvents someEvent_in, cFlowform flowform_in) {
			for (int i = 0; i < this.MyFlowforms.Length; i++) {
				if (this.MyFlowforms[i] == flowform_in) {
					switch (someEvent_in) {
						case eFlowformEvents.Closed:
							this.NotifyBase(eFlowformEvents.Closed, this);
							break;
						case eFlowformEvents.Back:
							this.MyFlowforms[i].Hide();
							this.myform_.Show();
							break;
					}
					break;
				}
			}
		}

		public virtual void Show() {
			this.myform_.Show();
		}
		public virtual void Hide() {
			this.myform_.Hide();
		}
	}
}