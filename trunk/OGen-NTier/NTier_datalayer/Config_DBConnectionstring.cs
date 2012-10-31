#region Copyright (C) 2002 Francisco Monteiro
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

	public struct Config_DBConnectionstring {
		#region public Config_DBConnectionstring(...);
		/// <summary>
		/// Used to store a config file connection string.
		/// </summary>
		/// <param name="connectionstring_in">The connection's connectionstring.</param>
		public Config_DBConnectionstring(
			string connectionstring_in
		) {
			this.connectionstring_ = connectionstring_in;
		}
		#endregion

		#region public Properties...
		#region public string Connectionstring { get; }
		private string connectionstring_;
		/// <summary>
		/// The connection's connectionstring.
		/// </summary>
		public string Connectionstring {
			get { return this.connectionstring_; }
		}
		#endregion
		#endregion
		#region public Methods...
		#region public static DBConnection newConfig_DBConnectionstring(...);
		/// <summary>
		/// Instantiates a new Config_DBConnectionstring.
		/// </summary>
		/// <param name="connectionString_in">connection string</param>
		/// <returns>new Config_DBConnectionstring</returns>
		public static Config_DBConnectionstring newConfig_DBConnectionstring(string connectionString_in) {
			return new Config_DBConnectionstring(
				connectionString_in
			);
		}
		#endregion
		#endregion
	}
}