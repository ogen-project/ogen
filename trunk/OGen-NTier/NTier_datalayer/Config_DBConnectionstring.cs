#region Copyright (C) 2002 Francisco Monteiro
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

#if NET_1_1
	public struct Config_DBConnectionstring {
#else
	public struct Config_DBConnectionstring : IEquatable<Config_DBConnectionstring> {
#endif
		#region public Config_DBConnectionstring(...);
		/// <summary>
		/// Used to store a config file connection string.
		/// </summary>
		/// <param name="connectionString_in">The connection's connectionstring.</param>
		public Config_DBConnectionstring(
			string connectionString_in
		) {
			this.connectionstring_ = connectionString_in;
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

#if NET_1_1
#else
		public override int GetHashCode() {
			unchecked {
				int _output = 17;
				_output = _output * 23 + this.connectionstring_.GetHashCode();
				return _output;
			}
		}
		public bool Equals(Config_DBConnectionstring other) {
			return
				(other.connectionstring_.Equals(this.connectionstring_));
		}
		public override bool Equals(object obj) {
			if (!(obj is Config_DBConnectionstring))
				return false;

			return Equals((Config_DBConnectionstring)obj);
		}

		public static bool operator ==(Config_DBConnectionstring aux1, Config_DBConnectionstring aux2) {
			return aux1.Equals(aux2);
		}

		public static bool operator !=(Config_DBConnectionstring aux1, Config_DBConnectionstring aux2) {
			return !aux1.Equals(aux2);
		}
#endif
		#endregion
	}
}