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

namespace OGen.NTier.lib.datalayer {
	public struct Config_DBConnectionstring {
		#region public Config_DBConnectionstring(...);
		/// <summary>
		/// Used to store a config file connection string.
		/// </summary>
		/// <param name="isDefault_in">Helps end user's datalayer figure out which connection(string) it's supposed to use.</param>
		/// <param name="generatedSQL_in">Indicates if code was generated over this connection(string).</param>
		/// <param name="isIndexed_andReadOnly_in">Indicates if connection's made over an indexed and read only database.</param>
		/// <param name="connectionstring_in">The connection's connectionstring.</param>
		public Config_DBConnectionstring(
			bool isDefault_in,
			bool generatedSQL_in, 
			bool isIndexed_andReadOnly_in,
			string connectionstring_in
		) {
			isdefault_ = isDefault_in;
			generatedsql_ = generatedSQL_in;
			isindexed_andreadonly_ = isIndexed_andReadOnly_in;
			connectionstring_ = connectionstring_in;
		}
		#endregion

		#region public Properties...
		#region public bool isDefault { get; }
		private bool isdefault_;
		/// <summary>
		/// Helps end user's datalayer figure out which connection(string) it's supposed to use.
		/// </summary>
		public bool isDefault {
			get { return isdefault_; }
		}
		#endregion
		#region public bool GeneratedSQL { get; }
		private bool generatedsql_;
		/// <summary>
		/// Indicates if code was generated over this connection(string).
		/// </summary>
		public bool GeneratedSQL {
			get { return generatedsql_; }
		}
		#endregion
		#region public bool isIndexed_andReadOnly { get; }
		private bool isindexed_andreadonly_;
		/// <summary>
		/// Indicates if connection's made over an indexed and read only database.
		/// </summary>
		public bool isIndexed_andReadOnly {
			get { return isindexed_andreadonly_; }
		}
		#endregion
		#region public string Connectionstring { get; }
		private string connectionstring_;
		/// <summary>
		/// The connection's connectionstring.
		/// </summary>
		public string Connectionstring {
			get { return connectionstring_; }
		}
		#endregion
		#endregion
		#region public Methods...
		#region public static DBConnection newConfig_DBConnectionstring(string parameters_in);
		/// <summary>
		/// Instantiates a new Config_DBConnectionstring.
		/// </summary>
		/// <param name="parameters_in">
		/// It must respect "[True|False]::[True|False]::[True|False]::some connection string like;Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;".<br/>
		/// Where:<br/>
		/// - 1st parameter represents the isDefault property<br/>
		/// - 2nd parameter represents GeneratedSQL property<br/>
		/// - 3rd parameter represents isIndexed_andReadOnly<br/>
		/// - 4th last parameter represents the Connectionstring property<br/>
		/// </param>
		/// <returns>new Config_DBConnectionstring</returns>
		public static Config_DBConnectionstring newConfig_DBConnectionstring(string parameters_in) {
			string [] _parameters = parameters_in.Replace("::", ((char)13).ToString()).Split((char)13);//new string[] { "::" }, StringSplitOptions.None);
			return new Config_DBConnectionstring(
				bool.Parse(_parameters[0]), 
				bool.Parse(_parameters[1]), 
				bool.Parse(_parameters[2]), 
				_parameters[3]
			);
		}
		#endregion
		#endregion
	}
}