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

namespace OGen.lib.collections {
	[AttributeUsage(
		 AttributeTargets.Property, // | AttributeTargets.Field, 
		 AllowMultiple = false
	)]
	public class ClaSSPropertyAttribute : System.Attribute {
		#region public ClaSSPropertyAttribute(...);
		public ClaSSPropertyAttribute(
			string name_in, 
			eType type_in
		) : this (
			name_in, 
			type_in, 
			true // default
		) {
		}
		public ClaSSPropertyAttribute(
			string name_in, 
			eType type_in, 
			bool synchronizeState_in
		) {
			name_ = name_in;
			type_ = type_in;
			synchronizestate_ = synchronizeState_in;
		}
		#endregion

		public enum eType {
			standard = 0, 
			aggregate = 1, 
			aggregate_collection = 2, 

			invalid = 3
		}

		#region public string Name { get; }
		private string name_;
		public string Name {
			get { return name_; }
		}
		#endregion
		#region public eType Type { get; }
		private eType type_;
		public eType Type {
			get { return type_; }
		}
		#endregion
		#region public bool SynchronizeState { get; }
		private bool synchronizestate_;
		public bool SynchronizeState {
			get { return synchronizestate_; }
			//set { synchronizestate_ = value; }
		}
		#endregion
	}
}