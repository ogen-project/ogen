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
using System.Data;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.lib.businesslayer {
	/// <summary>
	/// base implementation class for BusinessObject classes.
	/// </summary>
	public abstract class BDO__base {
		#region public Properties...
		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public abstract IRecordObject Record { get; }
		#endregion

//		#region public Methods - Record...
//		public bool Record_Fullmode {
//			get { return record.Fullmode; }
//		}
//		public virtual int Record_Current {
//			get { return record.Current; }
//		}
//		public virtual bool Record_isOpened {
//			get { return record.isOpened; }
//		}
//		public virtual int Record_Count {
//			get { return record.Count; }
//		}
//		public virtual DataTable Record_exposeDataTable {
//			get { return record.Record; }
//		}
//		//public virtual bool Record_Read() {
//		//	return record.Read();
//		//}
//		public virtual bool Record_EOR() {
//			return record.EOR();
//		}
//		public virtual void Record_Close() {
//			record.Close();
//		}
//		#endregion
	}
}