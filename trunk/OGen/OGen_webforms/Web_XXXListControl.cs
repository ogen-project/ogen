﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.PresentationLayer.WebForms {
	using System;
	using System.Web.UI.WebControls;

	public class Web_XXXListControl : IXXXListControl {
		public Web_XXXListControl(
			ListItemCollection listitemcollection_ref_in
		) {
			this.listitemcollection_ref_ = listitemcollection_ref_in;
		}
		private ListItemCollection listitemcollection_ref_;

		#region public int Count { get; }
		public int Count {
			get {
				return this.listitemcollection_ref_.Count;
			}
		}
		#endregion
		#region public void Add(...);
		public void Add(
			string Key_in,
			string Value_in
		) {
			this.listitemcollection_ref_.Add(
				new ListItem(Key_in, Value_in)
			);
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			this.listitemcollection_ref_.Clear();
		}
		#endregion

		#region public IXXXListItem this[int i] { get; }
		public IXXXListItem this[int i] {
			get {
				return new Web_XXXListItem(
					this.listitemcollection_ref_[i]
				);
			}
		} 
		#endregion
	}
}