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
using System.Xml.Serialization;
using System.Reflection;
using OGen.NTier.lib.businesslayer;

namespace OGen.NTier.lib.metadata.metadataBusiness {
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

			_output.root_metadatabusiness_ = ROOT + "." + METADATABUSINESS + "[" + index_in.ToString() + "]";
			_output.parent_ref = root_ref_in; // ToDos: now!
			if (root_ref_in != null) _output.root_ref = root_ref_in;
			#endregion

			#region Assembly _assembly = Assembly.Load(assemblyFilePath_in);
			Assembly _assembly = Assembly.LoadFile(assemblyFilePath_in);
			if (_assembly == null) {
				throw new Exception(String.Format(
					"can't load assembly 'assemblyName_in'\n at: {0}.{1}.Load_fromAssembly();",
					typeof(XS__metadataBusiness).Namespace,
					typeof(XS__metadataBusiness).Name,
					assemblyFilePath_in
				));
			}
			#endregion

			int _class_index;
			int _method_index;
			int _property_index;
			Type[] _types = _assembly.GetTypes();
			for (int t = 0; t < _types.Length; t++) {
				Type _type = (Type)_types[t];

				object[] _attibutes = _type.GetCustomAttributes(
					typeof(BOClassAttribute),
					true//false
				);
				if (
					(_attibutes.Length > 0)
					&&
					(_type.Name.IndexOf("BO0_") != 0)
					&&
					(_type.Name.IndexOf("BDO0_") != 0)
				) {
//Console.Write("{0};  ", _type.Name);

					for (int c = 0; c < _attibutes.Length; c++) {
						BOClassAttribute _attribute 
							= (BOClassAttribute)_attibutes[c];
//Console.WriteLine(
//    "name:{0};",
//    _attribute.Name
//);
_output.Classes.ClassCollection.Add(
	out _class_index, 
	//_attribute.Name
	(_type.Name.IndexOf("BO_") == 0)
		? _type.Name.Substring(3)
		: (
			(_type.Name.IndexOf("BDO_") == 0)
				? _type.Name.Substring(4)
				: _type.Name
		)
);

						MethodInfo[] _methods = _type.GetMethods(
							BindingFlags.Public |
							BindingFlags.Instance
						);
						for (int m = 0; m < _methods.Length; m++) {
							if (Attribute.IsDefined(
								_methods[m],
								typeof(BOMethodAttribute)
							)) {
								Attribute[] _attributes = Attribute.GetCustomAttributes(
									_methods[m],
									typeof(BOMethodAttribute),
									true
								);

								_method_index = -1;
								for (int a = 0; a < _attributes.Length; a++) {
									if (_attributes[a].GetType() == typeof(BOMethodAttribute)) {
										BOMethodAttribute _methodattribute
											= (BOMethodAttribute)_attributes[a];
//Console.WriteLine(
//    "\tname:{0}; distribute:{1};",
//    _methodattribute.Name,
//    _methodattribute.Distribute
//);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection.Add(
	out _method_index, 
	_methods[m].Name
);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].Distribute = _methodattribute.Distribute;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[
	_method_index
].OutputType
	= //(_methods[m].ReturnType.ToString() == "System.Void") 
	//? "void" 
	//: 
	string.Format(
		"{0}.{1}", 
		_methods[m].ReturnType.Namespace, 
		_methods[m].ReturnType.Name
	);

									}
								}
//Console.WriteLine(
//    "\t.{0}(",
//    _methods[m].Name
//);
								ParameterInfo[] _parameterinfo = _methods[m].GetParameters();
								for (int p = 0; p < _parameterinfo.Length; p++) {
//Console.WriteLine(
//    "\t\tname:{0}; type:{1}; isOut:{2}; isByRef:{3}; isEnum:{4}; isClass:{5}; isValueType:{6}", 
//    _parameterinfo[p].Name, 
//    _parameterinfo[p].ParameterType, 
//    _parameterinfo[p].IsOut,
//    _parameterinfo[p].ParameterType.IsByRef,
//    _parameterinfo[p].ParameterType.IsEnum, 
//    _parameterinfo[p].ParameterType.IsClass, 
//    _parameterinfo[p].ParameterType.IsValueType
//);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection.Add(
	out _property_index, 
	_parameterinfo[p].Name
);
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].isOut = _parameterinfo[p].IsOut;
_output.Classes.ClassCollection[_class_index].Methods.MethodCollection[_method_index].Parameters.ParameterCollection[
	_property_index
].Type = string.Format(
	"{0}.{1}",
	_parameterinfo[p].ParameterType.Namespace,
	(_parameterinfo[p].ParameterType.Name.IndexOf('&') >= 0)
		? _parameterinfo[p].ParameterType.Name.Substring(0, _parameterinfo[p].ParameterType.Name.Length - 1)
		: _parameterinfo[p].ParameterType.Name

);
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