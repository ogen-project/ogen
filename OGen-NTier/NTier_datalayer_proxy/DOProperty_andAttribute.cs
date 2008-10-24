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