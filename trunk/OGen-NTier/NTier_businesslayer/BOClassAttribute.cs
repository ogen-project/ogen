﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.BusinessLayer {
	using System;

	/// <summary>
	/// BusinessObject Class Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class BOClassAttribute : System.Attribute {
		#region public BOClassAttribute(...);
		/// <param name="name_in">Name</param>
		public BOClassAttribute(
			string name_in, 
			string type_in
		) {
			this.name_ = name_in;
			this.type_ = type_in;
		}
		#endregion

		#region public string Name { get; }
		private string name_;

		/// <summary>
		/// Name
		/// </summary>
		public string Name {
			get { return this.name_; }
		}
		#endregion

		#region public string Type { get; }
		private string type_;

		/// <summary>
		/// Type
		/// </summary>
		public string Type {
			get { return this.type_; }
		}
		#endregion
	}
}