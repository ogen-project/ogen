﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DataLayer {
	using System;
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// Invalid Record State Exception, Record already opened.
	/// </summary>
	[Serializable()]
	public class InvalidRecordStateException_alreadyOpened : Exception {

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidRecordStateException_alreadyOpened">InvalidRecordStateException_alreadyOpened</see> class.
		/// </summary>
		public InvalidRecordStateException_alreadyOpened(
		) : base (
			"invalid Record state, Record already opened"
		) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidRecordStateException_alreadyOpened">InvalidRecordStateException_alreadyOpened</see> class.
		/// </summary>
		/// <param name="message">Error description message.</param>
		public InvalidRecordStateException_alreadyOpened(
			string message
		) : base (
			message
		) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidRecordStateException_alreadyOpened">InvalidRecordStateException_alreadyOpened</see> class.
		/// </summary>
		/// <param name="message">Error description message.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public InvalidRecordStateException_alreadyOpened(
			string message,
			Exception innerException
		) : base (
			message,
			innerException
		) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidRecordStateException_alreadyOpened">InvalidRecordStateException_alreadyOpened</see> class.
		/// </summary>
		/// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
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