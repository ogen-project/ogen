#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Web.UI.WebControls;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public class htmlDatePicker : Anthem.TextBox {
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		public DateTime Date {
			get {
				string[] _splitstring = this.Text.Split('/');
				if (_splitstring.Length == 3) {
					int _year;
					int _month;
					int _day;

					if (!int.TryParse(_splitstring[2], out _year))
						return datetime_minvalue_;

					if (!int.TryParse(_splitstring[1], out _month))
						return datetime_minvalue_;

					if (!int.TryParse(_splitstring[0], out _day))
						return datetime_minvalue_;

					return new DateTime(_year, _month, _day);
				}

				return datetime_minvalue_;
			}
			set {
				if (value <= datetime_minvalue_) {
					this.Text = "";
				} else {
					this.Text
						=
						//value.ToString("dd/MM/yyyy")
							string.Format(
								"{0}/{1}/{2}",
								value.Day,
								value.Month,
								value.Year
							)
						;
				}
			}
		}
	}
}