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

	public class FlowformForm {
		public FlowformForm(
			dNotifyBase notifyBase_in, 
			dNotifyBase notifyBase_aboutNext_in
		) {
			this.notifybase_ = notifyBase_in;
			this.notifybase_aboutnext_ = notifyBase_aboutNext_in;
		}

		#region Delegations...
		public delegate void dNotifyBase(FlowformFormEvents someEvent_in);
		private dNotifyBase notifybase_ = null;
		private dNotifyBase notifybase_aboutnext_ = null;

		public void NotifyBase(FlowformFormEvents someEvent_in) {
			if (someEvent_in == FlowformFormEvents.Next) {
				if (this.notifybase_aboutnext_ != null) this.notifybase_aboutnext_(someEvent_in);
			} else {
				if (this.notifybase_ != null) this.notifybase_(someEvent_in);
			}
		}
		#endregion

		//#region Events...
		public void btnBack_Click(object sender, System.EventArgs e) {
			this.NotifyBase(FlowformFormEvents.Back);
		}
		public void btnNext_Click(object sender, System.EventArgs e) {
			this.NotifyBase(FlowformFormEvents.Next);
		}
		public void FlowformForm_Closed(object sender, System.EventArgs e) {
			this.NotifyBase(FlowformFormEvents.Closed);
		}
		//#endregion
	}
}