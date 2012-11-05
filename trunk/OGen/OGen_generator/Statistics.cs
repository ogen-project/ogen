#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.Generator {
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Statistics {
		public Statistics(
			bool countLines_in,
			bool countBytes_in,
			bool threadSafe_in
		) {
			this.countlines_ = countLines_in;
			this.countbytes_ = countBytes_in;
			this.threadsafe_ = threadSafe_in;

			this.lines_ = 0;
			this.bytes_ = 0;
		}

		#region public bool CountLines { get; }
		private bool countlines_;

		public bool CountLines {
			get {
				return this.countlines_;
			}
		}
		#endregion
		#region public bool CountBytes { get; }
		private bool countbytes_;

		public bool CountBytes {
			get {
				return this.countbytes_;
			}
		}
		#endregion
		#region public bool ThreadSafe { get; }
		private bool threadsafe_;

		public bool ThreadSafe {
			get {
				return this.threadsafe_;
			}
		}
		#endregion
		#region public int Lines { get; set; }
		private object lines_locker = new object();
		private int lines_;

		public int Lines {
			get {
				return this.lines_;
			}
		}
		#endregion
		#region public int Bytes { get; set; }
		private object bytes_locker = new object();
		private int bytes_;

		public int Bytes {
			get {
				return this.bytes_;
			}
		}
		#endregion

		#region public void Lines_Add(string text_in);
		public void Lines_Add(string text_in) {
			if (!this.countlines_)
				return;

			int _lines = text_in.Split
				(new string[] {
				"\r\n",
				"\n"
			},
				StringSplitOptions.None
			).Length;

			if (this.threadsafe_) {
				lock (this.lines_locker) {
					this.lines_ += _lines;
				}
			} else {
				this.lines_ += _lines;
			}
		}
		#endregion
		#region public void Bytes_Add(string text_in);
		public void Bytes_Add(string text_in) {
			if (!this.countbytes_)
				return;

			if (this.threadsafe_) {
				lock (this.bytes_locker) {
					this.bytes_ += text_in.Length;
				}
			} else {
				this.bytes_ += text_in.Length;
			}
		}
		#endregion
		#region public string Bytes_ToString();
		public string Bytes_ToString(bool readableBytes_in) {
			return OGen.Libraries.Utilities.Bytes_ToString(
				this.bytes_,
				readableBytes_in
			);
		}
		#endregion
	}
}