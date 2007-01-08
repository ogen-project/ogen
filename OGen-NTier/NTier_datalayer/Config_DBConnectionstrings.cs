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
				ConfigModes(application_in).Length * 
				DBServerTypes(application_in).Length
			);
			for (int _cfg = 0; _cfg < ConfigModes(application_in).Length; _cfg++) {
				for (int _db = 0; _db < DBServerTypes(application_in).Length; _db++) {
					Add(
						DBServerTypes(application_in)[_db], 
						ConfigModes(application_in)[_cfg], 
						Config_DBConnectionstring.newConfig_DBConnectionstring(
							System.Configuration.ConfigurationSettings.AppSettings[string.Format(
								"{0}:DBConnection:{1}:{2}",
								application_in, 
								ConfigModes(application_in)[_cfg],
								DBServerTypes(application_in)[_db].ToString()
							)]
						)
					);
				}
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
		#region public DBConnection this[eDBServerTypes dbServerType_in, string configMode_in] { get; }
		public Config_DBConnectionstring this[eDBServerTypes dbServerType_in, string configMode_in] {
			get {
				return (Config_DBConnectionstring)dbconnections_[string.Format(
					"{0}:{1}",
					configMode_in,
					dbServerType_in
				)];

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
		public static string[] Applications {
			get {
				if (applications__ == null) {
					applications__ 
						= System.Configuration.ConfigurationSettings.AppSettings[
							"applications"
						].Split(':');
				}
				return applications__;
			}
		}
		#endregion
		#endregion

		#region private Methods...
		#region private void Add(...);
		private void Add(
			eDBServerTypes dbServerType_in, 
			string configMode_in, 
			Config_DBConnectionstring dbConnection_in
		) {
			dbconnections_.Add(
				string.Format(
					"{0}:{1}",
					configMode_in,
					dbServerType_in
				), 
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
			configmodes__ = null;
			dbservertypes__ = null;
			dbconnectionstrings__ = null;
		}
		#endregion
		#region public static string[] ConfigModes(string application_in);
		private static Hashtable configmodes__;
		/// <summary>
		/// Supported Config Modes (i.e. DEBUG, !DEBUG, etc.) for a specific application.
		/// </summary>
		/// <param name="application_in">name of the application</param>
		/// <returns></returns>
		public static string[] ConfigModes(string application_in) {
			if (configmodes__ == null) configmodes__ = new Hashtable();
			if (!configmodes__.Contains(application_in)) {
				configmodes__.Add(
					application_in, 
					System.Configuration.ConfigurationSettings.AppSettings[
						string.Format(
							"{0}:ConfigModes", 
//							ApplicationName
							application_in
						)
					].Split(':')
				);
			}
			return (string[])configmodes__[application_in];
		}
		#endregion
		#region public static eDBServerTypes[] DBServerTypes(string application_in);
		private static Hashtable dbservertypes__;
		/// <summary>
		/// Supported DB Server Types.
		/// </summary>
		public static eDBServerTypes[] DBServerTypes(string application_in) {
			if (dbservertypes__ == null) dbservertypes__ = new Hashtable();
			if (!dbservertypes__.Contains(application_in)) {
				string[] _supporteddbservertypes 
					= System.Configuration.ConfigurationSettings.AppSettings[
						string.Format(
							"{0}:DBServerTypes", 
//							ApplicationName
							application_in
						)
					].Split(':');

				eDBServerTypes[] _dbservertypes = new eDBServerTypes[_supporteddbservertypes.Length];
				for (int i = 0; i < _supporteddbservertypes.Length; i++) {
					_dbservertypes[i] 
						= OGen.lib.datalayer.utils.DBServerTypes.convert.FromName(
							_supporteddbservertypes[i]
						);
				}

				dbservertypes__.Add(
					application_in, 
					_dbservertypes
				);
			}

			return (eDBServerTypes[])dbservertypes__[application_in];
		}
		#endregion
		#region public static Config_DBConnectionstrings DBConnectionstrings(string application_in);
		private static Hashtable dbconnectionstrings__;
		public static Config_DBConnectionstrings DBConnectionstrings(string application_in) {
			if (dbconnectionstrings__ == null) dbconnectionstrings__ = new Hashtable();
			if (!dbconnectionstrings__.Contains(application_in)) {
				dbconnectionstrings__.Add(
					application_in, 
					new Config_DBConnectionstrings(application_in)
				);
			}

			return (Config_DBConnectionstrings)dbconnectionstrings__[application_in];
		}
		#endregion
		#endregion
	}
}