﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.lib.datalayer {
	using System;
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// Invalid Record State Exception, Record already opened.
	/// </summary>
	[Serializable()]
	public class InvalidRecordStateException_alreadyOpened : Exception {
		public InvalidRecordStateException_alreadyOpened(
		) : base (
			"invalid Record state, Record already opened"
		) {
		}
		public InvalidRecordStateException_alreadyOpened(
			string message
		) : base (
			message
		) {
		}
		public InvalidRecordStateException_alreadyOpened(
			string message,
			Exception innerException
		) : base (
			message,
			innerException
		) {
		}
		protected InvalidRecordStateException_alreadyOpened(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context
		) : base(
			info, 
			context
		) {
		}
	}
}