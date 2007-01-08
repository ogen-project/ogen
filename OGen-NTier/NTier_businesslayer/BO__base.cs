#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Data;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.lib.businesslayer {
	/// <summary>
	/// base implementation class for BusinessObject classes.
	/// </summary>
	public abstract class BO__base {
		#region public Properties...
		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public abstract iRecordObject Record { get; }
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