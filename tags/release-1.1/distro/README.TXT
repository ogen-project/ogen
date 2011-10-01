
Read Me
=========

Scripts should be run in the order they are numbered, you should read the fallowing script description before you run them




Instalation Scripts Description
=================================

win-100-generate-keys.bat
	- generates keys needed to compile assemblies with strong name so they can be added to the GAC

win-110-generate-app.config.bat
	- generates app.config with your local path to OGen project

win-120-buildAssembies-7.1-registry-tweak4visualstudio.js
	- makes GAC registered assemblies visivle in visual studio 2001 and 2003, by adding a key to the windows registry,
	if you don't use visual studio 2001 or 2003, then you don't need to run this script

win-120-buildAssembies-7.1.sln
	- visual studio 2003 solution, you should set build configuration to RELEASE and compile this solution

win-120-buildAssembies-8.sln
	- sharp development / visual studio 2005 solution, you should set build configuration to RELEASE and compile this solution

win-130-copyAssemblies-1.1.bat
	- copies (visual studio 2003) compiled assemblies (framework 1.1) to bin directory

win-130-copyAssemblies-2.0.bat
	- copies (sharp development / visual studio 2005) compiled assemblies (framework 2.0) to bin directory

win-140-installAssemblies-intoGAC-1.1.bat
	- adds (visual studio 2003) compiled assemblies (framework 1.1) to the GAC

win-140-installAssemblies-intoGAC-2.0.bat
	- adds (sharp development / visual studio 2005) compiled assemblies (framework 2.0) to the GAC

win-150-OGen.Doc.Templates-install-1.1.bat
	- copies (visual studio 2003) compiled assembly (framework 1.1) for the OGen-Doc Templates to bin directory
	and generates web.config file

win-150-OGen.Doc.Templates-install-2.0.bat
	- copies (sharp development / visual studio 2005) compiled assembly (framework 2.0) for the OGen-Doc Templates to bin directory
	and generates web.config file

win-150-OGen.NTier.Templates-install-1.1.bat
	- copies (visual studio 2003) compiled assembly (framework 1.1) for the OGen-NTier Templates to bin directory
	and generates web.config file

win-150-OGen.NTier.Templates-install-2.0.bat
	- copies (sharp development / visual studio 2005) compiled assembly (framework 2.0) for the OGen-NTier Templates to bin directory
	and generates web.config file


Uninstallation Scripts Description
====================================

win-200-OGen.Doc.Templates-uninstall-1.1.bat
	- deletes OGen-Doc Templates (visual studio 2003) compiled assembly (framework 1.1) from the bin directory

win-200-OGen.Doc.Templates-uninstall-2.0.bat
	- deletes OGen-Doc Templates (sharp development / visual studio 2005) compiled assembly (framework 2.0) from the bin directory

win-200-OGen.NTier.Templates-uninstall-1.1.bat
	- deletes OGen-NTier Templates (visual studio 2003) compiled assembly (framework 1.1) from the bin directory

win-200-OGen.NTier.Templates-uninstall-2.0.bat
	- deletes OGen-NTier Templates (sharp development / visual studio 2005) compiled assembly (framework 2.0) from the bin directory

win-210-uninstallAssemblies-fromGAC-1.1.bat
	- removes (visual studio 2003) compiled assemblies (framework 1.1) from the GAC

win-210-uninstallAssemblies-fromGAC-2.0.bat
	- removes (sharp development / visual studio 2005) compiled assemblies (framework 2.0) from the GAC

win-220-deleteAssemblies-1.1.bat
	- deletes (visual studio 2003) compiled assemblies (framework 1.1) from the bin directory

win-220-deleteAssemblies-2.0.bat
	- deletes (sharp development / visual studio 2005) compiled assemblies (framework 2.0) from the bin directory

win-290-clear_bin.bat
	- deletes bin and obj folders from all OGen projects
