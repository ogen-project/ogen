#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;

namespace OGen.lib.presentationlayer.winforms.Flowforms {
	public abstract class cFlowform {
		#region public cFlowform(...);
		protected cFlowform(
			dNotifyBase notifyBase_in, 
			int numFlowformForms_in
		) {
			notifybase_ = notifyBase_in;
			myflowforms_ = new cFlowform[numFlowformForms_in];
		}
		public virtual void Dispose() {
			if (MyFlowforms != null) {
				for (int i = 0; i < MyFlowforms.Length; i++) {
					if (MyFlowforms[i] != null)
						MyFlowforms[i].Dispose();
					MyFlowforms[i] = null;
				}
			}

			myform_.Dispose();
		}
		#endregion

		#region Delegations...
		public delegate void dNotifyBase(eFlowformEvents someEvent_in, cFlowform flowform_in);
		private dNotifyBase notifybase_ = null;

		public void NotifyBase(eFlowformEvents someEvent_in, cFlowform flowform_in) {
			if (notifybase_ != null) {
				notifybase_(someEvent_in, flowform_in);
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
			get { return myflowforms_; }
		}
		#endregion
		protected abstract System.Windows.Forms.Form myform_ { get; }

		protected void MyForm_notifiedMe(eFlowformFormEvents someEvent_in) {
			switch (someEvent_in) {
				case eFlowformFormEvents.Closed:
					NotifyBase(eFlowformEvents.Closed, this);
					break;
				case eFlowformFormEvents.Back:
					NotifyBase(eFlowformEvents.Back, this);
					break;
			}
		}
		protected void MyFlowforms_notifiedMe(eFlowformEvents someEvent_in, cFlowform flowform_in) {
			for (int i = 0; i < MyFlowforms.Length; i++) {
				if (MyFlowforms[i] == flowform_in) {
					switch (someEvent_in) {
						case eFlowformEvents.Closed:
							NotifyBase(eFlowformEvents.Closed, this);
							break;
						case eFlowformEvents.Back:
							MyFlowforms[i].Hide();
							myform_.Show();
							break;
					}
					break;
				}
			}
		}

		public virtual void Show() {
			myform_.Show();
		}
		public virtual void Hide() {
			myform_.Hide();
		}
	}
}