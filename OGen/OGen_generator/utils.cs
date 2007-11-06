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
using System.Reflection;

using OGen.lib.collections;

namespace OGen.lib.generator {
	#region public struct MetaFile { ... }
	public struct MetaFile {
		public MetaFile(
			string path_in,
			string root_in
		) {
			Path = path_in;
			Root = root_in;
		}

		public string Path;
		public string Root;
	}
	#endregion
	public interface MetadataInterface {
		string Read_fromRoot(string what_in);

		void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in
		);
	}

	public class utils {
		private utils() { }

		public delegate void IterationFoundDelegate(string message_in);

		#region public static int MetaFile_find(...);
		public static int MetaFile_find(
			MetaFile[] metaFiles_in,
			string root_in
		) {
			for (int i = 0; i < metaFiles_in.Length; i++) {
				if (metaFiles_in[i].Root == root_in) {
					return i;
				}
			}

			throw new Exception(string.Format(
				"can't find: {0}",
				root_in
			));
		}
		#endregion

		#region public static bool rootExpression_TryParse(...);
		public static bool rootExpression_TryParse(
			string rootExpression_in,
			string whereRootLike_in,
			out string begin_out,
			out string index_out,
			out string end_out
		) {
			if (
				(begin_out = rootExpression_in.Substring(0, whereRootLike_in.Length))
					== whereRootLike_in
			) {
				string _end_aux
					= rootExpression_in.Substring(whereRootLike_in.Length);
				int _aux = _end_aux.IndexOf(']');
				index_out = _end_aux.Substring(0, _aux);
				end_out = _end_aux.Substring(_aux);

				return true;
			} else {
				begin_out = string.Empty;
				index_out = string.Empty;
				end_out = string.Empty;

				return false;
			}
		}
		#endregion

		public static string ReflectThrough(
			object someClass_in,
			string path_in,
			IterationFoundDelegate iteration_found_in,
			string iteration_in,
			string pathTranslated_in,
			bool returnValue_in,
			bool anyAttribute_notJustXml
		) {
			bool _valueHasBeenFound = false;

			return ReflectThrough(
				someClass_in,
				path_in,
				iteration_found_in,
				iteration_in,
				pathTranslated_in,
				returnValue_in,
				anyAttribute_notJustXml,
				out _valueHasBeenFound
			);
		}
		public static string ReflectThrough(
			object someClass_in, 
			string path_in, 
			IterationFoundDelegate iteration_found_in, 
			string iteration_in, 
			string pathTranslated_in, 
			bool returnValue_in, 
			bool anyAttribute_notJustXml, 
			out bool valueHasBeenFound_out
		) {
			valueHasBeenFound_out = false;

#if DEBUG
const bool _usePerformance = true;
#endif

			if (
#if DEBUG
_usePerformance && (
#endif
				(
					returnValue_in
					&&
					(
						(path_in.Length > iteration_in.Length)
						||
						(path_in != iteration_in.Substring(0, path_in.Length))
					)
				)
				||
				(
					!returnValue_in
					&&
					(
						(pathTranslated_in.Length > iteration_in.Length)
						||
						(pathTranslated_in != iteration_in.Substring(0, pathTranslated_in.Length))
					)
				)
#if DEBUG
)
#endif
			) {
				// performance tweak, compares path to avoid looking in the wrong direction 
				return null;
			}

			if (iteration_in == pathTranslated_in) {
				if (iteration_found_in != null) iteration_found_in(path_in);
			}

//#if DEBUG
//Console.WriteLine(
//	"\n\t---\n\t{0}.{1}.ReflectThrough:{7}(\n\t\tsomeClass_in:\"{2}.{3}\",\n\t\tpath_in:\"{4}\",\n\t\titeration_in:\"{5}\",\n\t\tpathTranslated_in:\"{6}\"\n\t)\n\t---",
//	typeof(utils).Namespace,
//	typeof(utils).Name,
//	someClass_in.GetType().Namespace,
//	someClass_in.GetType().Name,
//	path_in,
//	iteration_in,
//	pathTranslated_in,
//	returnValue_in ? "READ" : "ITERATE"
//);
//#endif
//#if DEBUG
//Console.Write("{{{0}}}", path_in.ToUpper());
//#endif

			PropertyInfo[] _properties;
			System.Xml.Serialization.XmlElementAttribute _elementAttribute;
			System.Xml.Serialization.XmlAttributeAttribute _attribute;
			object _value;
			Array _array;
			string _output = null;
			bool _isAttribute = false;
			bool _isElement = false;
			string _attributename = string.Empty;
			int _indexOfSquareBrackets_begin = -1;
			int _indexOfSquareBrackets_end = -1;
			string _aux1;
			string _aux2;

			_properties = someClass_in.GetType().GetProperties(
				BindingFlags.Public | 
				BindingFlags.Instance
			);
			for (int _prop = 0; _prop < _properties.Length; _prop++) {
				_isAttribute = Attribute.IsDefined(
					_properties[_prop], 
					typeof(System.Xml.Serialization.XmlAttributeAttribute)
				);
				_isElement = Attribute.IsDefined(
					_properties[_prop], 
					typeof(System.Xml.Serialization.XmlElementAttribute)
				);

				if (
					_isElement
&&
(
	(_properties[_prop].PropertyType != typeof(string))
	&&
	(_properties[_prop].PropertyType != typeof(decimal))
	&&
	(_properties[_prop].PropertyType != typeof(int))
	&&
	(_properties[_prop].PropertyType != typeof(bool))
	&&
	(_properties[_prop].PropertyType != typeof(DateTime))
)
				) {
					#region XmlElement...
					_value = _properties[_prop].GetValue(someClass_in, null);
					if (_value == null) continue;

					_elementAttribute 
						= (System.Xml.Serialization.XmlElementAttribute)Attribute.GetCustomAttributes(
							_properties[_prop], 
							typeof(System.Xml.Serialization.XmlElementAttribute), 
							true
						)[0];

					_aux1 = string.Format(
						"{0}.{1}",
						path_in,
						_elementAttribute.ElementName
					);
					_indexOfSquareBrackets_begin = _aux1.Length;
					if (
#if DEBUG
_usePerformance && (
#endif

(_indexOfSquareBrackets_begin > iteration_in.Length)

						||
						(
							_aux1 != iteration_in.Substring(
								0,
								_indexOfSquareBrackets_begin
							)
						)
						||
						(
							(
								(_aux2 = iteration_in.Substring(
									_indexOfSquareBrackets_begin, 
									1
								)) != "["
							)
							&&
							(_aux2 != ".")
						)
#if DEBUG
)
#endif
					) {
						continue;
					}

					if (_value.GetType().IsArray) {
						if (
#if DEBUG
_usePerformance && 
#endif
							returnValue_in
						) {
							_indexOfSquareBrackets_end
								= iteration_in.IndexOf(
									']',
									_indexOfSquareBrackets_begin + 1
								);
						}

						_array = (Array)_value;
						for (
							int i = 
								(
#if DEBUG
_usePerformance &&
#endif
									returnValue_in
								)
								?
									// performance tweak, goes straight to the iteration 
									// when (returnValue_in == true)
									int.Parse(
										iteration_in.Substring(
											_indexOfSquareBrackets_begin + 1,
											_indexOfSquareBrackets_end - (_indexOfSquareBrackets_begin + 1)
										)
									)
								: 
									0
							;

							i < _array.Length;
							i++
						) {
							_output = ReflectThrough(
								_array.GetValue(i), 
								string.Format(
									"{0}.{1}[{2}]", 
									path_in, 
									_elementAttribute.ElementName, 
									i
								), 
								iteration_found_in, 
								iteration_in, 
								string.Format(
									"{0}.{1}[n]", 
									pathTranslated_in, 
									_elementAttribute.ElementName
								), 
								returnValue_in, 
								anyAttribute_notJustXml,
								out valueHasBeenFound_out
							);
							if (returnValue_in && valueHasBeenFound_out)
								return _output;
						}
					} else {
						_output = ReflectThrough(
							_value, 
							string.Format(
								"{0}.{1}", 
								path_in, 
								_elementAttribute.ElementName
							), 
							iteration_found_in, 
							iteration_in, 
							string.Format(
								"{0}.{1}", 
								pathTranslated_in, 
								_elementAttribute.ElementName
							), 
							returnValue_in, 
							anyAttribute_notJustXml,
							out valueHasBeenFound_out
						);
						if (returnValue_in && valueHasBeenFound_out)
							return _output;
					}
					#endregion
				} else if (
					_isAttribute
					||
					anyAttribute_notJustXml
					||
(
	_isElement
	&&
	(
		(_properties[_prop].PropertyType == typeof(string))
	)
)
				) {
					#region XmlAttribute...
					if (
						anyAttribute_notJustXml 
						&& 
						!_properties[_prop].CanRead
					) continue;

					try {
						_value = _properties[_prop].GetValue(someClass_in, null);
					} catch (Exception _ex) {
						throw new Exception(string.Format(
							"\n---\n{0}.{1}.ReflectThrough(\n\tsomeClass_in:\"{2}.{3}\",\n\tpath_in:\"{4}\",\n\titeration_in:\"{5}\",\n\tpathTranslated_in:\"{6}\"\n)\n---\n{7}", 
							typeof(utils).Namespace, 
							typeof(utils).Name, 
							someClass_in.GetType().Namespace, 
							someClass_in.GetType().Name, 
							path_in, 
							iteration_in, 
							pathTranslated_in, 
							_ex.Message
						));
					}

					if (_value == null) continue;

					if (_isAttribute) {
						_attribute 
							= (System.Xml.Serialization.XmlAttributeAttribute)Attribute.GetCustomAttributes(
								_properties[_prop], 
								typeof(System.Xml.Serialization.XmlAttributeAttribute), 
								true
							)[0];
						_attributename = _attribute.AttributeName;
					} else if (_isElement) {
						_elementAttribute 
							= (System.Xml.Serialization.XmlElementAttribute)Attribute.GetCustomAttributes(
								_properties[_prop], 
								typeof(System.Xml.Serialization.XmlElementAttribute), 
								true
							)[0];
						_attributename = _elementAttribute.ElementName;
					} else {
						_attributename = _properties[_prop].Name;
					}

					if (string.Format("{0}.{1}", path_in, _attributename) == iteration_in) {
						valueHasBeenFound_out = true;
						return _value.ToString();
					}
					#endregion
				}
			}

			return _output;
		}
	}
}
