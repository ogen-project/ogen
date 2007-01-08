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