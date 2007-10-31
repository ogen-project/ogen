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
using System.Collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Fields_PK {
		#region public cDBMetadata_Table_Fields_PK(...);
		public cDBMetadata_Table_Fields_PK(
			cDBMetadata_Table parent_ref_in, 
			bool onlyPK_in
		) {
			onlyPK_ = onlyPK_in;
			parent_ref_ = parent_ref_in;
		}
		#endregion

		#region private Properties...
		private bool onlyPK_;
		#endregion
		#region public Properties...
		#region public cDBMetadata_Table Parent_ref { get; }
		private cDBMetadata_Table parent_ref_;
		public cDBMetadata_Table Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get {
				int Count_out = 0;
				for (int f = 0; f < parent_ref_.Fields.Count; f++)
					if (
						(
							onlyPK_
							&&
							parent_ref_.Fields[f].isPK
						)
						||
						(
							!onlyPK_
							&&
							!parent_ref_.Fields[f].isPK
						)
					)
						Count_out++;

						return Count_out;
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field this[int index_in] { get; }
		public cDBMetadata_Table_Field this[int index_in] {
			get {
				int _c = -1;
				for (int f = 0; f < parent_ref_.Fields.Count; f++) {
					if (
						(
							onlyPK_
							&&
							parent_ref_.Fields[f].isPK
						)
						||
						(
							!onlyPK_
							&&
							!parent_ref_.Fields[f].isPK
						)
					) {
						_c++;
						if (_c == index_in)
							return parent_ref_.Fields[f];
					}
				}

				return null;
			}
		}
		#endregion
		#endregion
	}
}