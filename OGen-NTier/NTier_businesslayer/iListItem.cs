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

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.lib.businesslayer {
	/// <summary>
	/// ListItem Interface.
	/// </summary>
	public interface IListItem {
		/// <summary>
		/// List Item Text.
		/// </summary>
		string ListItemText { get; }

		/// <summary>
		/// List Item Value.
		/// </summary>
		string ListItemValue { get; }

		//void Record_open(int Search, params object SearchParameters);
		//void Record_close();
		//bool Record_read();

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		IRecordObject Record { get; }
	}
}