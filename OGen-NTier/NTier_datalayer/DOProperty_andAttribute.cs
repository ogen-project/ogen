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
using System.Reflection;

namespace OGen.NTier.lib.datalayer {
	public struct DOProperty_andAttribute {
		#region public DOProperty_andAttribute(...);
		public DOProperty_andAttribute(
			PropertyInfo doProperty_in, 
			DOPropertyAttribute doAttribute_in
		) {
			doproperty_ = doProperty_in;
			doattribute_ = doAttribute_in;
		}
		#endregion

		#region public PropertyInfo DOProperty { get; set; }
		private PropertyInfo doproperty_;
		public PropertyInfo DOProperty {
			get { return doproperty_;  }
			set { doproperty_ = value;  }
		}
		#endregion
		#region public DOPropertyAttribute DOAttribute { get; set; }
		private DOPropertyAttribute doattribute_;
		public DOPropertyAttribute DOAttribute {
			get { return doattribute_; }
			set { doattribute_ = value; }
		}
		#endregion

		#region public static DOProperty_andAttribute[] getFromInstance(...);
		public static DOProperty_andAttribute[] getFromInstance(
			object doInstance_in
		) {
			DOProperty_andAttribute[] _dopropatt_out;
			PropertyInfo[] _properties
				= doInstance_in.GetType().GetProperties(
					BindingFlags.Public | 
					BindingFlags.Instance
				);

			int _count = 0;
			for (int p = 0; p < _properties.Length; p++) {
				if (Attribute.IsDefined(
					_properties[p],
					typeof(DOPropertyAttribute)
				)) {
					_count++;
				}
			}

			_dopropatt_out = new DOProperty_andAttribute[_count];
			_count = 0;
			for (int p = 0; p < _properties.Length; p++) {
				if (Attribute.IsDefined(
					_properties[p],
					typeof(DOPropertyAttribute)
				)) {
					_dopropatt_out[_count] = new DOProperty_andAttribute(
						_properties[p], 
						(DOPropertyAttribute)(
							Attribute.GetCustomAttributes(_properties[p])
						)[0]
					);

					_count++;
				}
			}

			return _dopropatt_out;
		}
		#endregion
	}
}