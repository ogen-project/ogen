#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.Metadata.MetadataBusiness {
	using System;
	using System.Reflection;
	using System.Xml.Serialization;
	using OGen.NTier.Libraries.BusinessLayer;

	[System.Xml.Serialization.XmlRootAttribute("metadataBusiness")]
	#if NET_1_1
	public class XS__metadataBusiness : XS0__metadataBusiness {
	#else
	public partial class XS__metadataBusiness {
	#endif

		public static XS__metadataBusiness Load_fromAssembly(
			string assemblyFilePath_in, 

			XS__RootMetadata root_ref_in, 
			int index_in
		) {
			#region XS__metadataBusiness _output = ...;
			XS__metadataBusiness _output = new XS__metadataBusiness();

			_output.root_metadatabusiness_ = string.Concat(ROOT, ".", METADATABUSINESS, "[", index_in.ToString(System.Globalization.CultureInfo.CurrentCulture), "]");
			_output.parent_ref = root_ref_in; // ToDos: now!
			if (root_ref_in != null) _output.root_ref = root_ref_in;
			#endregion

			#region Assembly _assembly = Assembly.LoadFrom(assemblyFilePath_in);
			Assembly _assembly
				//= Assembly.LoadFile(assemblyFilePath_in);
				= Assembly.LoadFrom(assemblyFilePath_in);
			//_assembly.GetFiles(true);
			//_assembly.GetReferencedAssemblies();

			if (_assembly == null) {
				throw new Exception(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"can't load assembly 'assemblyName_in'\n at: {0}.{1}.Load_fromAssembly();",
					typeof(XS__metadataBusiness).Namespace,
					typeof(XS__metadataBusiness).Name,
					assemblyFilePath_in
				));
			}
			#endregion

			//bool _isBO = false;
			//bool _isBDO = false;
			int _class_index;
			int _method_index;
			int _property_index;
			Type[] _types = _assembly.GetTypes();

#if NET_2_0
			Array.Sort(
				_types,
				delegate(
					Type arg1,
					Type arg2
				) {
					return string.Compare(
						arg1.Name, 
						arg2.Name,
						false,
						System.Globalization.CultureInfo.CurrentCulture
					);
				}
			);
#endif

			for (int t = 0; t < _types.Length; t++) {
				Type _type = (Type)_types[t];

				object[] _classattributes = _type.GetCustomAttributes(
					typeof(BOClassAttribute),
					true//false
				);
				if (
					(_classattributes.Length > 0)
					&&
					(_type.Name.IndexOf("SBO_", StringComparison.CurrentCulture) == 0)
				) {
					for (int ca = 0; ca < _classattributes.Length; ca++) {
//						BOClassAttribute _attribute 
//							= (BOClassAttribute)_classattributes[ca];

_output.Classes.ClassCollection.Add(
	out _class_index, 
	//_attribute.Name
	(_type.Name.IndexOf("SBO_", StringComparison.CurrentCulture) == 0)
		? _type.Name.Substring(4)
		: _type.Name
);
_output.Classes.ClassCollection[_class_index].Namespace
	= _type.Namespace;
_output.Classes.ClassCollection[_class_index].Type
	= XS_BoEnumeration.invalid;

						MethodInfo[] _methods = _type.GetMethods(
							BindingFlags.Public |
							//BindingFlags.Instance 
							BindingFlags.Static
						);

#if NET_2_0
						Array.Sort(
							_methods,
							delegate(
								MethodInfo arg1,
								MethodInfo arg2
							) {
								return string.Compare(
									arg1.Name,
									arg2.Name,
									false,
									System.Globalization.CultureInfo.CurrentCulture
								);
							}
						);
#endif

						for (int m = 0; m < _methods.Length; m++) {
							if (Attribute.IsDefined(
								_methods[m],
								typeof(BOMethodAttribute)
							)) {
								Attribute[] _methodattributes = Attribute.GetCustomAttributes(
									_methods[m],
									typeof(BOMethodAttribute),
									true
								);

								_method_index = -1;
								for (int ma = 0; ma < _methodattributes.Length; ma++) {
									if (_methodattributes[ma].GetType() == typeof(BOMethodAttribute)) {
										BOMethodAttribute _methodattribute
											= (BOMethodAttribute)_methodattributes[ma];

_output.Classes.ClassCollection[_class_index].Methods.MethodCollection.Add(
	out _method_index, 
	_methods[m].Name
);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].Distribute = _methodattribute.Distribute;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].isSearch = _methodattribute.isSearch;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].IPParamNum = _methodattribute.IPParamNum;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].OutputType
	= OGen.Libraries.Utilities.Type_ToString(_methods[m].ReturnType);

									}
								}

								ParameterInfo[] _parameterinfo = _methods[m].GetParameters();
								for (int p = 0; p < _parameterinfo.Length; p++) {

_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection.Add(
	out _property_index, 
	_parameterinfo[p].Name
);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].isOut = _parameterinfo[p].IsOut;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].Type = OGen.Libraries.Utilities.Type_ToString(_parameterinfo[p].ParameterType);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].isRef = (_parameterinfo[p].ParameterType.IsByRef && !_parameterinfo[p].IsOut);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].isParams = false;

								}
							}
						}
					}
				}
			}

			return _output;
		}
	}
}