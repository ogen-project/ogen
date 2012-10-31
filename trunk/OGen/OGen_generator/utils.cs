#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.lib.generator {
	using System;
	using System.Reflection;

	using OGen.lib.collections;

	#region public struct MetaFile { ... }
	public struct MetaFile {
		public MetaFile(
			string path_in,
			string root_in
		) {
			this.Path = path_in;
			this.Root = root_in;
		}

		public string Path;
		public string Root;
	}
	#endregion
	#region public interface MetadataInterface { ... }
	public interface MetadataInterface {
		string Read_fromRoot(string what_in);

		void IterateThrough_fromRoot(
			string iteration_in,
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in,
			ref bool valueHasBeenFound_out
		);
	}
	#endregion

#if NET_1_1
	public class utils { private utils() {}
#else
	public static class utils {
#endif

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
				System.Globalization.CultureInfo.CurrentCulture,
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
				(whereRootLike_in.Length <= rootExpression_in.Length)
				&&
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

//		#region public static string ReflectThrough(...);
		#region public static string ReflectThrough(...);
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
				ref _valueHasBeenFound,
				true
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
			ref bool valueHasBeenFound_out
		) {
			return ReflectThrough(
				someClass_in,
				path_in,
				iteration_found_in,
				iteration_in,
				pathTranslated_in,
				returnValue_in,
				anyAttribute_notJustXml,
				ref valueHasBeenFound_out,
				true
			);
		}
		#endregion

		private class CacheItem {
			public CacheItem(
				string translation_in,
				System.Collections.Generic.List<string> iterarions_in
			) {
				this.Translation = translation_in;
				this.Iterations = iterarions_in;
			}

			public string Translation;
			public System.Collections.Generic.List<string> Iterations;
		}
		private static System.Collections.Generic.Dictionary<string, CacheItem> reflectthrough_cache
			= new System.Collections.Generic.Dictionary<string, CacheItem>();
		private static object reflectthrough_locker = new object();

		public static void ReflectThrough_Cache_Clear() {
			lock (reflectthrough_locker) {
				reflectthrough_cache.Clear();
			}
		}

		private static string ReflectThroughRunAndCache(
			IterationFoundDelegate iteration_found_in,
			System.Collections.Generic.List<string> iterations_in,
			string what_in,
			string translation_in,
			bool useCache_in
		) {
			if (
				(iteration_found_in != null)
				&&
				(iterations_in != null)
			) {
				for (int m = 0; m < iterations_in.Count; m++) {
					iteration_found_in(iterations_in[m]);
				}
			}

			if (useCache_in) {

				// check before lock
				if (!reflectthrough_cache.ContainsKey(what_in)) {

					lock (reflectthrough_locker) {

						// double check, thread safer!
						if (!reflectthrough_cache.ContainsKey(what_in)) {

							// initialization...
							// ...attribution (last thing before unlock)
							reflectthrough_cache.Add(
								what_in, 
								(
									(translation_in == null)
									&&
									(iterations_in == null)
								)
									? null
									: new CacheItem(
										translation_in,
										iterations_in
									)
							);
						}
					}
				}
			}

			return translation_in;
		}

		public static string ReflectThrough(
			object someClass_in, 
			string path_in, 
			IterationFoundDelegate iteration_found_in, 
			string iteration_in, 
			string pathTranslated_in, 
			bool returnValue_in, 
			bool anyAttribute_notJustXml, 
			ref bool valueHasBeenFound_out,
			bool useCache_in
		) {
			string _cacheKey = iteration_in;

			CacheItem _cacheitem;
			if (
				useCache_in
				&&
				reflectthrough_cache.ContainsKey(_cacheKey)
			) {
				_cacheitem = reflectthrough_cache[_cacheKey];

				if (_cacheitem == null) return null;

				for (int i = 0; i < _cacheitem.Iterations.Count; i++) {
					iteration_found_in(_cacheitem.Iterations[i]);
				}
				valueHasBeenFound_out = _cacheitem.Iterations.Count > 0;

				return _cacheitem.Translation;
			}



			System.Collections.Generic.List<string> _iteration_found_out = new System.Collections.Generic.List<string>();
			string _output = null;

#if DEBUG
const bool _usePerformance2 = false;
const bool _usePerformance3 = true;
const bool _usePerformance5 = false;
#else
const bool _usePerformance2 = false;
const bool _usePerformance3 = true;
const bool _usePerformance5 = false;
#endif

			if (
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
			) {
				// performance tweak, compares path to avoid looking in the wrong direction

				return ReflectThroughRunAndCache(
					iteration_found_in,
					null,
					_cacheKey,
					null,
					useCache_in
				);
			}

			if (iteration_in == pathTranslated_in) {
				valueHasBeenFound_out = true;

				if (iteration_found_in != null) _iteration_found_out.Add(path_in);
			}

			PropertyInfo[] _properties;
			System.Xml.Serialization.XmlElementAttribute _elementAttribute;
			System.Xml.Serialization.XmlAttributeAttribute _attribute;
			object _value;
			Array _array;
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
						System.Globalization.CultureInfo.CurrentCulture,
						"{0}.{1}",
						path_in,
						_elementAttribute.ElementName
					);
					_indexOfSquareBrackets_begin = _aux1.Length;
					if (
//#if DEBUG
_usePerformance2 && (
//#endif

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
//#if DEBUG
)
//#endif
					) {
						continue;
					}

					if (_value.GetType().IsArray) {
						if (
//#if DEBUG
_usePerformance3 && 
//#endif
							returnValue_in
&&
(_indexOfSquareBrackets_begin + 1 < iteration_in.Length)
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
//#if DEBUG
_usePerformance5 &&
//#endif
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
									System.Globalization.CultureInfo.CurrentCulture,
									"{0}.{1}[{2}]", 
									path_in, 
									_elementAttribute.ElementName, 
									i
								), 
								delegate(string message_in) {
									if (iteration_found_in != null) _iteration_found_out.Add(message_in);
								},
								iteration_in, 
								string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"{0}.{1}[n]", 
									pathTranslated_in, 
									_elementAttribute.ElementName
								), 
								returnValue_in, 
								anyAttribute_notJustXml,
								ref valueHasBeenFound_out,
								false
							);
							if (returnValue_in && valueHasBeenFound_out) {

								return ReflectThroughRunAndCache(
									iteration_found_in,
									_iteration_found_out,
									_cacheKey,
									_output,
									useCache_in
								);
							}
						}
					} else {
						_output = ReflectThrough(
							_value, 
							string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"{0}.{1}", 
								path_in, 
								_elementAttribute.ElementName
							), 
							delegate(string message_in) {
								if (iteration_found_in != null) _iteration_found_out.Add(message_in);
							},
							iteration_in, 
							string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"{0}.{1}", 
								pathTranslated_in, 
								_elementAttribute.ElementName
							), 
							returnValue_in, 
							anyAttribute_notJustXml,
							ref valueHasBeenFound_out,
							false
						);
						if (returnValue_in && valueHasBeenFound_out) {

							return ReflectThroughRunAndCache(
								iteration_found_in,
								_iteration_found_out,
								_cacheKey,
								_output,
								useCache_in
							);
						}
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
						string _ex_message = string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"\n---\n{0}.{1}.ReflectThrough(\n\tsomeClass_in:\"{2}.{3}\",\n\tpath_in:\"{4}\",\n\titeration_in:\"{5}\",\n\tpathTranslated_in:\"{6}\"\n)\n---\n{7}",
							typeof(utils).Namespace,
							typeof(utils).Name,
							someClass_in.GetType().Namespace,
							someClass_in.GetType().Name,
							path_in,
							iteration_in,
							pathTranslated_in,
							_ex.Message
						);
#if DEBUG
_value = null;
Console.WriteLine(_ex_message);
#else
						throw new Exception(_ex_message);
#endif
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

					if (
						string.Format(
							System.Globalization.CultureInfo.CurrentCulture, 
							"{0}.{1}", 
							path_in, 
							_attributename
						) == iteration_in
					) {
						valueHasBeenFound_out = true;
						_output = _value.ToString();

						return ReflectThroughRunAndCache(
							iteration_found_in,
							_iteration_found_out,
							_cacheKey,
							_output,
							useCache_in
						);
					}
					#endregion
				} 
				//else {
				//    throw new Exception(string.Format(
				//        System.Globalization.CultureInfo.CurrentCulture,
				//        "class: {0}\npath: {1}\niteration: {2}\npathTranslated: {3}\nreturnValue: {4}\nanyAttribute_notJustXml: {5}\n", 
				//        someClass_in.GetType().ToString(), 
				//        path_in, 
				//        iteration_in, 
				//        pathTranslated_in, 
				//        returnValue_in, 
				//        anyAttribute_notJustXml
				//    ));
				//}
			}

			return ReflectThroughRunAndCache(
				iteration_found_in,
				_iteration_found_out,
				_cacheKey,
				_output,
				useCache_in
			);
		}
//		#endregion
	}
}
