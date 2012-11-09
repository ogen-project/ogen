#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DataLayer {
	using System;

	public class DBSimpleConnectionstring {
		#region public DBSimpleConnectionstring(...);
		public DBSimpleConnectionstring(
			DBServerTypes dbServerType_in, 
			string connectionString_in
		) {
			this.dbservertype_ = dbServerType_in;
			this.connectionstring_ = connectionString_in;
		}
		#endregion

		#region public DBServerTypes DBServerType { get; set; }
		protected DBServerTypes dbservertype_;

		public DBServerTypes DBServerType {
			get { return this.dbservertype_; }
			set { this.dbservertype_ = value; }
		}
		#endregion
		#region public string Connectionstring { get; set; }
		protected string connectionstring_;

		public string Connectionstring {
			get { return this.connectionstring_; }
			set { this.connectionstring_ = value; }
		}
		#endregion
	}
}
