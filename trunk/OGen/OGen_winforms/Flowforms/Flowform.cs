#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.PresentationLayer.WinForms.FlowForms {
	using System;

	public abstract class Flowform : IDisposable {
		#region public Flowform(...);
		protected Flowform(
			OGen.Libraries.PresentationLayer.WinForms.FlowForms.FlowformNotifyBase notifyBase_in, 
			int numFlowformForms_in
		) {
			this.notifybase_ = notifyBase_in;
			this.myflowforms_ = new Flowform[numFlowformForms_in];
		}
		~Flowform() {
			this.Dispose(false);
		}

		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing_in) {
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
		private OGen.Libraries.PresentationLayer.WinForms.FlowForms.FlowformNotifyBase notifybase_ = null;

		public void NotifyBase(FlowformEvents someEvent_in, Flowform flowform_in) {
			if (this.notifybase_ != null) {
				this.notifybase_(someEvent_in, flowform_in);
			} else {
				switch (someEvent_in) {
					case FlowformEvents.Closed:
						this.Dispose();
						break;
					case FlowformEvents.Back:
						// do nothing...
						break;
				}
			}
		}
		#endregion

		#region protected Flowform[] MyFlowforms { get; }
		private Flowform[] myflowforms_;
		protected Flowform[] MyFlowforms {
			get { return this.myflowforms_; }
		}
		#endregion
		protected abstract System.Windows.Forms.Form myform_ { get; }

		protected void MyForm_notifiedMe(FlowformFormEvents someEvent_in) {
			switch (someEvent_in) {
				case FlowformFormEvents.Closed:
					this.NotifyBase(FlowformEvents.Closed, this);
					break;
				case FlowformFormEvents.Back:
					this.NotifyBase(FlowformEvents.Back, this);
					break;
			}
		}
		protected void MyFlowforms_notifiedMe(FlowformEvents someEvent_in, Flowform flowform_in) {
			for (int i = 0; i < this.MyFlowforms.Length; i++) {
				if (this.MyFlowforms[i] == flowform_in) {
					switch (someEvent_in) {
						case FlowformEvents.Closed:
							this.NotifyBase(FlowformEvents.Closed, this);
							break;
						case FlowformEvents.Back:
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