#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Dia.Libraries.Metadata.Diagram {
	using System;
	using System.Collections.Generic;
	using System.Text;

#if NET_1_1
	public struct ForeignKey {
#else
	public struct ForeignKey : IEquatable<ForeignKey> {
#endif
		public ForeignKey(
			string tableFieldName_in, 

			string foreignKey_TableName_in, 
			string foreignKey_TableFieldName_in
		) {
			this.TableFieldName = tableFieldName_in;

			this.ForeignKey_TableName = foreignKey_TableName_in;
			this.ForeignKey_TableFieldName = foreignKey_TableFieldName_in;
		}

		public string TableFieldName;

		public string ForeignKey_TableName;
		public string ForeignKey_TableFieldName;

#if NET_1_1
#else
		public override int GetHashCode() {
			unchecked {
				int _output = 17;
				_output = _output * 23 + this.TableFieldName.GetHashCode();
				_output = _output * 23 + this.ForeignKey_TableName.GetHashCode();
				_output = _output * 23 + this.ForeignKey_TableFieldName.GetHashCode();
				return _output;
			}
		}
		public bool Equals(ForeignKey other) {
			return
				(other.TableFieldName.Equals(this.TableFieldName)) &&
				(other.ForeignKey_TableName.Equals(this.ForeignKey_TableName)) &&
				(other.ForeignKey_TableFieldName.Equals(this.ForeignKey_TableFieldName));
		}
		public override bool Equals(object obj) {
			if (!(obj is ForeignKey))
				return false;

			return Equals((ForeignKey)obj);
		}

		public static bool operator ==(ForeignKey aux1, ForeignKey aux2) {
			return aux1.Equals(aux2);
		}

		public static bool operator !=(ForeignKey aux1, ForeignKey aux2) {
			return !aux1.Equals(aux2);
		}
#endif
	}
}