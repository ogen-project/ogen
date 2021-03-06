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
	/// BusinessObject Method Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class BOMethodAttribute : System.Attribute {
		#region public BOMethodAttribute(...);
		/// <param name="name_in">Name</param>
		/// <param name="distribute_in">Distribute</param>
		/// <param name="isSearch_in">isSearch</param>
		/// <param name="ipParamNum_in">ipParamNum (indexed to 0)</param>
		public BOMethodAttribute(
			string name_in,
			bool distribute_in, 
			bool isSearch_in,
			int ipParamNum_in
		) {
			this.name_ = name_in;
			this.distribute_ = distribute_in;
			this.issearch_ = isSearch_in;
			this.ipparamnum_ = ipParamNum_in;
		}

		/// <param name="name_in">Name</param>
		/// <param name="distribute_in">Distribute</param>
		[Obsolete("Use BOMethodAttribute(string, bool, bool, int) instead")]
		public BOMethodAttribute(
			string name_in,
			bool distribute_in
		) : this (
			name_in,
			distribute_in, 
			false, 
			-1
		) {
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
		#region public bool Distribute { get; }
		private bool distribute_;

		/// <summary>
		/// Distribute
		/// </summary>
		public bool Distribute {
			get { return this.distribute_; }
		}
		#endregion
		#region public bool IsSearch { get; }
		private bool issearch_;

		/// <summary>
		/// IsSearch
		/// </summary>
		public bool IsSearch {
			get { return this.issearch_; }
		}
		#endregion
		#region public int IPParamNum { get; }
		private int ipparamnum_;

		/// <summary>
		/// IPParamNum
		/// </summary>
		public int IPParamNum {
			get { return this.ipparamnum_; }
		}
		#endregion
	}
}