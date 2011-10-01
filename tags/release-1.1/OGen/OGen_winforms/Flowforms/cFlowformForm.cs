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

namespace OGen.lib.presentationlayer.winforms.Flowforms {
	public class cFlowformForm {
		public cFlowformForm(
			dNotifyBase notifyBase_in, 
			dNotifyBase notifyBase_aboutNext_in
		) {
			notifybase_ = notifyBase_in;
			notifybase_aboutnext_ = notifyBase_aboutNext_in;
		}

		#region Delegations...
		public delegate void dNotifyBase(eFlowformFormEvents someEvent_in);
		private dNotifyBase notifybase_ = null;
		private dNotifyBase notifybase_aboutnext_ = null;

		public void NotifyBase(eFlowformFormEvents someEvent_in) {
			if (someEvent_in == eFlowformFormEvents.Next) {
				if (notifybase_aboutnext_ != null) notifybase_aboutnext_(someEvent_in);
			} else {
				if (notifybase_ != null) notifybase_(someEvent_in);
			}
		}
		#endregion

		//#region Events...
		public void btnBack_Click(object sender, System.EventArgs e) {
			NotifyBase(eFlowformFormEvents.Back);
		}
		public void btnNext_Click(object sender, System.EventArgs e) {
			NotifyBase(eFlowformFormEvents.Next);
		}
		public void FlowformForm_Closed(object sender, System.EventArgs e) {
			NotifyBase(eFlowformFormEvents.Closed);
		}
		//#endregion
	}
}