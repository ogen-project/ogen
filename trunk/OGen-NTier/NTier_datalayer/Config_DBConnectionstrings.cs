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
using System.Collections;

using OGen.lib.datalayer;

namespace OGen.NTier.lib.datalayer {
	public class Config_DBConnectionstrings {
		#region public Config_DBConnectionstrings();
		/// <summary>
		/// Used to store config file connection strings.
		/// </summary>
		public Config_DBConnectionstrings(string application_in) {
			dbconnections_ = new System.Collections.Hashtable(
				DBServerTypes(application_in).Length
			);
			for (int _db = 0; _db < DBServerTypes(application_in).Length; _db++) {
				Add(
					DBServerTypes(application_in)[_db], 
					Config_DBConnectionstring.newConfig_DBConnectionstring(
						#if !NET_1_1
						System.Configuration.ConfigurationManager.ConnectionStrings
						#else
						System.Configuration.ConfigurationSettings.AppSettings
						#endif
							[string.Format(
								"{0}:{1}",
								application_in, 
								DBServerTypes(application_in)[_db].ToString()
							)]
						#if !NET_1_1
								.ConnectionString
						#endif
					)
				);
			}
		}
		#endregion
		#region static Config_DBConnectionstrings();
		static Config_DBConnectionstrings() {
			Reset();
		}
		#endregion

		#region private Properties...
		private System.Collections.Hashtable dbconnections_;
		#endregion
		#region public Properties...
		#region public DBConnection this[string dbServerType_in] { get; }
		public Config_DBConnectionstring this[string dbServerType_in] {
			get {
				return (Config_DBConnectionstring)dbconnections_[dbServerType_in];

			}
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return dbconnections_.Count; }
		}
		#endregion
		#endregion
		#region public static Properties...
		#region public static string[] Applications { get; }
		private static string[] applications__;
		private static object applications__locker = new object();

		public static string[] Applications {
			get {

				// check before lock
				if (applications__ == null) {

					lock (applications__locker) {

						// double check, thread safer!
						if (applications__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							applications__ = 
								#if !NET_1_1
								System.Configuration.ConfigurationManager.AppSettings
								#else
								System.Configuration.ConfigurationSettings.AppSettings
								#endif
									[
										"applications"
									].Split('|');
						}
					}
				}

				return applications__;
			}
		}
		#endregion
		#endregion

		#region private Methods...
		#region private void Add(...);
		private void Add(
			string dbServerType_in, 
			Config_DBConnectionstring dbConnection_in
		) {
			dbconnections_.Add(
				dbServerType_in,
				dbConnection_in
			);
		}
		#endregion
		#endregion
		#region public static Methods...
		#region public static void Reset();
		public static void Reset() {
//			applicationname__ = null;
			applications__ = null;
			dbservertypes__.Clear();
			dbconnectionstrings__.Clear();
		}
		#endregion
		#region public static string[] DBServerTypes(string application_in);
		private static Hashtable dbservertypes__ = new Hashtable();
		private static object dbservertypes__locker = new object();

		/// <summary>
		/// Supported DB Server Types.
		/// </summary>
		public static string[] DBServerTypes(
			string application_in
		) {

			// check before lock
			if (!dbservertypes__.Contains(application_in)) {

				lock (dbservertypes__locker) {

					// double check, thread safer!
					if (!dbservertypes__.Contains(application_in)) {

						// initialization...
						string[] _supporteddbservertypes =
							#if !NET_1_1
							System.Configuration.ConfigurationManager.AppSettings
							#else
							System.Configuration.ConfigurationSettings.AppSettings
							#endif
								[
									string.Format(
										"{0}:DBServerTypes", 
//										ApplicationName
										application_in
									)
								].Split('|');

						string[] _dbservertypes = new string[_supporteddbservertypes.Length];
						for (int i = 0; i < _supporteddbservertypes.Length; i++) {
							_dbservertypes[i] = _supporteddbservertypes[i];
						}

						// ...attribution (last thing before unlock)
						dbservertypes__.Add(
							application_in, 
							_dbservertypes
						);
					}
				}
			}

			return (string[])dbservertypes__[application_in];
		}
		#endregion
		#region public static Config_DBConnectionstrings DBConnectionstrings(string application_in);
		private static Hashtable dbconnectionstrings__ = new Hashtable();
		private static object dbconnectionstrings__locker = new object();

		public static Config_DBConnectionstrings DBConnectionstrings(
			string application_in
		) {

			// check before lock
			if (!dbconnectionstrings__.Contains(application_in)) {

				lock (dbconnectionstrings__locker) {

					// double check, thread safer!
					if (!dbconnectionstrings__.Contains(application_in)) {

						// initialization...
						// ...attribution (last thing before unlock)
						dbconnectionstrings__.Add(
							application_in, 
							new Config_DBConnectionstrings(application_in)
						);
					}
				}
			}

			return (Config_DBConnectionstrings)dbconnectionstrings__[application_in];
		}
		#endregion
		#endregion
	}
}
