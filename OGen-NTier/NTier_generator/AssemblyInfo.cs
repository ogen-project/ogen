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
using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following
// attributes.
//
// change them to the information which is associated with the assembly
// you compile.
//
[assembly: AssemblyTitle("OGen.NTier.lib.generator")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Francisco Monteiro")]
[assembly: AssemblyProduct("OGen")]
[assembly: AssemblyCopyright("Copyright (C) 2002 Francisco Monteiro")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all values by your own or you can build default build and revision
// numbers with the '*' character (the default):
//
[assembly: AssemblyVersion("0.1.1000.20000")]

// The following attributes specify the key for the sign of your assembly. See the
// .NET Framework documentation for more information about signing.
// This is not required, if you don't want signing let these attributes like they're.
//
#if !DEBUG
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("..\\..\\..\\..\\_admin\\OGen.no-svn.snk")]
#else
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("..\\..\\..\\OGen-shared.snk")]
#endif
