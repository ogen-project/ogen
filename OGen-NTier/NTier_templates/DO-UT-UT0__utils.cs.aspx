<%--

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

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_metadata.CopyrightText != string.Empty) && (_aux_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_metadata.CopyrightText%>
/*

<%=_aux_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Data;
using NUnit.Framework;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using <%=_aux_metadata.Namespace%>.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer.UTs {
	internal class UT0__utils {
		private UT0__utils() {}
		#region static UT0__utils();
		static UT0__utils() {
			dbconnections__ = null;
		}
		#endregion

		#region public static cDBConnection[] DBConnections { get; }
		private static cDBConnection[] dbconnections__;
		public static cDBConnection[] DBConnections {
			get {
				if (dbconnections__ == null) {
					Config_DBConnectionstring _dbcon;

					int _count = 0;
					for (int _db = 0; _db < Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName).Length; _db++) {
						_dbcon = Config_DBConnectionstrings.DBConnectionstrings(DO__utils.ApplicationName)[
							Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db], 
							"DEBUG"
						];
						if (_dbcon.GeneratedSQL) {
							_count++;
						}
					}

					dbconnections__ = new cDBConnection[_count];
					_count = 0;
					for (int _db = 0; _db < Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName).Length; _db++) {
						_dbcon = Config_DBConnectionstrings.DBConnectionstrings(DO__utils.ApplicationName)[
							Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db],
							"DEBUG"
						];
						if (_dbcon.GeneratedSQL) {
							dbconnections__[_count++] = new cDBConnection(
								Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db], 
								_dbcon.Connectionstring
							);
						}
					}
				}
				return dbconnections__;
			}
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>