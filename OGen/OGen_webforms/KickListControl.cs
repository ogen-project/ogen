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
using System.Collections.Generic;

namespace OGen.lib.presentationlayer.webforms {
	public class KickListControl {
		public KickListControl(
			IXXXListControl listitemcollection_ref_in
		) {
			listitemcollection_ref_ = listitemcollection_ref_in;
		}

		public IXXXListControl listitemcollection_ref_;

		public const string UNDEFINED = "-- undefined --";

		public static string Transform(
			string text_in
		) {
			return text_in.Replace("__", " - ").Replace('_', ' ');
		}

		#region protected void bind_pre(...);
		public void bind_pre(
			bool allowNull_in
		) {
			listitemcollection_ref_.Clear();
			if (allowNull_in) {
				listitemcollection_ref_.Add(UNDEFINED, "");
			}
		}
		#endregion

		#region public void SelectedValue__set(...);
		public void SelectedValue__set(
			string[] selectedValue_in
		) {
			for (int i = 0; i < listitemcollection_ref_.Count; i++) {
				listitemcollection_ref_[i].Selected = false;
				for (int j = 0; j < selectedValue_in.Length; j++) {
					if (listitemcollection_ref_[i].Value == selectedValue_in[j]) {
						listitemcollection_ref_[i].Selected = true;
						break;
					}
				}
			}
		}

		public void SelectedValue__set(
			string selectedValue_in
		) {
			if (selectedValue_in == "") {
				for (int i = 0; i < listitemcollection_ref_.Count; i++) {
					listitemcollection_ref_[i].Selected = false;
				}
			} else {
				string[] _selectedValues
					= selectedValue_in.Split('|');

				SelectedValue__set(
					_selectedValues
				);
			}
		}
		#endregion
		#region public T[] SelectedValue__get<T>(...);
		public T[] SelectedValue__get<T>(
		) {
			List<T> _output = new List<T>(listitemcollection_ref_.Count);
			for (int i = 0; i < listitemcollection_ref_.Count; i++) {
				if (listitemcollection_ref_[i].Selected) {
					_output.Add(
						(T)Convert.ChangeType(
							listitemcollection_ref_[i].Value,
							typeof(T)
						)
					);
				}
			}

			return _output.ToArray();
		}
		#endregion


		#region public void Bind__arrayOf<T>(...);
		public delegate string ListitemValueDelegate<T>(T item_in);
		public delegate string ListitemTextDelegate<T>(T item_in);

		public void Bind__arrayOf<T>(
			string selectedValue_in,
			bool allowNull_in,
			T[] items_in,
			ListitemValueDelegate<T> listitemValue_in,
			ListitemTextDelegate<T> listitemText_in
		) {
			if (items_in == null) {
				listitemcollection_ref_.Clear();
				listitemcollection_ref_.Add(
					"",
					"ERROR!"
				);
				return;
			}

			bind_pre(
				allowNull_in
			);

			foreach (T _item in items_in) {
				listitemcollection_ref_.Add(
#if DEBUG
					string.Format(
						"{0} ({1})",
						Transform(listitemText_in(_item)),
						listitemValue_in(_item)
					), 
#else
					Transform(listitemText_in(_item)),
#endif
					listitemValue_in(_item)
				);
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion
		#region public void Bind__arrayOf<V, T>(...);
		public void Bind__arrayOf<V, T>(
			string selectedValue_in,
			bool allowNull_in,
			OGen.NTier.lib.datalayer.SO__ListItem<V, T>[] items_in
		) {
			if (items_in == null) {
				listitemcollection_ref_.Clear();
				listitemcollection_ref_.Add(
					"",
					"ERROR!"
				);
				return;
			}

			bind_pre(
				allowNull_in
			);

			bind__arrayof<V, T>(
				selectedValue_in,
				items_in
			);
		}

		public void Bind__arrayOf<V, T>(
			string selectedValue_in,
			OGen.NTier.lib.datalayer.SO__ListItem<V, T>[] items_in
		) {
			if (items_in == null) {
				listitemcollection_ref_.Clear();
				listitemcollection_ref_.Add(
					"",
					"ERROR!"
				);
				return;
			}

			bind__arrayof<V, T>(
				selectedValue_in,
				items_in
			);
		}

		private void bind__arrayof<V, T>(
			string selectedValue_in,
			OGen.NTier.lib.datalayer.SO__ListItem<V, T>[] items_in
		) {
			foreach (OGen.NTier.lib.datalayer.SO__ListItem<V, T> _item in items_in) {
				listitemcollection_ref_.Add(
#if DEBUG
					string.Format(
						"{0} ({1})", 
						Transform(_item.ListItem_Text.ToString()),
						_item.ListItem_Value.ToString()
					), 
#else
					Transform(_item.ListItem_Text.ToString()),
#endif
					_item.ListItem_Value.ToString()
				);
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		#region public void SelectedValues__set_arrayOf<T>(...);
		public void SelectedValues__set_arrayOf<T>(
			T[] items_in,
			ListitemValueDelegate<T> listitemValue_in
		) {
			if (items_in == null) return;

			string[] _selection;
			_selection = new string[items_in.Length];
			for (int i = 0; i < items_in.Length; i++) {
				_selection[i] = listitemValue_in(items_in[i]);
			}

			SelectedValue__set(_selection);
		}

		//public delegate bool ListitemConditionalSetDelegate<T>(T item_in);

		public void SelectedValues__set_arrayOf<T>(
			T[] items_in,
			ListitemValueDelegate<T> listitemValue_in,
			ListitemConditionalSetDelegate<T> setConditionVerifies_in
		) {
			if (items_in == null) return;

			string[] _selection;
			int _count = 0;
			for (int i = 0; i < items_in.Length; i++) {
				if (setConditionVerifies_in(items_in[i])) {
					_count++;
				}
			}
			_selection = new string[_count];
			_count = 0;
			for (int i = 0; i < items_in.Length; i++) {
				if (setConditionVerifies_in(items_in[i])) {
					_selection[_count] = listitemValue_in(items_in[i]);
					_count++;
				}
			}

			SelectedValue__set(_selection);
		}
		#endregion
		#region public void SelectedValues__set_arrayOf<V, T>(...);
		public void SelectedValues__set_arrayOf<V, T>(
			OGen.NTier.lib.datalayer.ISO__ListItem<V, T>[] items_in
		) {
			if (items_in == null) return;

			string[] _selection = new string[items_in.Length];
			for (int i = 0; i < items_in.Length; i++) {
				_selection[i] = items_in[i].ListItem_Value.ToString();
			}

			SelectedValue__set(_selection);
		}

		public delegate bool ListitemConditionalSetDelegate<I>(
			I item_in
		);
		public void SelectedValues__set_arrayOf<V, T, I>(
			I[] items_in,
			ListitemConditionalSetDelegate<I> setConditionVerifies_in
		)
			where I : OGen.NTier.lib.datalayer.ISO__ListItem<V, T>
		{
			if (items_in == null) return;

			string[] _selection;
		    int _count = 0;
		    for (int i = 0; i < items_in.Length; i++) {
				if (setConditionVerifies_in(items_in[i])) {
					_count++;
				}
		    }
		    _selection = new string[_count];
		    _count = 0;
		    for (int i = 0; i < items_in.Length; i++) {
				if (setConditionVerifies_in(items_in[i])) {
		            _selection[_count] = items_in[i].ListItem_Value.ToString();
		            _count++;
		        }
		    }

			SelectedValue__set(_selection);
		}
		#endregion


		#region public void Bind__Enum(...);
		#region protected void bind__enum_post(...);
		protected void bind__enum_post(
			string[] enumItems_in,
			Type enumType_in,

			string selectedValue_in,
			bool allowNull_in
		) {
			bind_pre(
				allowNull_in
			);

			long _value;
			foreach (string _enumItem in enumItems_in) {
				//_value = (long)Enum.Parse(enumType_in, _enumItem);
				_value = (long)Convert.ChangeType(
					Enum.Parse(enumType_in, _enumItem), 
					typeof(long)
				);

				if (_value >= 0) {
					listitemcollection_ref_.Add(
						Transform(_enumItem),
						_value.ToString()
					);
				}
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		public void Bind__Enum(
			string selectedValue_in,
			bool allowNull_in,

			bool sortByName_in,

			Type enumType_in
		) {
			string[] _enumItems = Enum.GetNames(enumType_in);

			if (sortByName_in) {
				Array.Sort<string>(_enumItems);
			}

			bind__enum_post(
				_enumItems,
				enumType_in,

				selectedValue_in,
				allowNull_in
			);
		}
		#endregion

		#region public void Bind__Copy(...);
		public void Bind__Copy(
			KickListBox from_in,

			string selectedValue_in,
			bool allowNull_in
		) {
			if (
				allowNull_in
				//&&
				//!(
				//    (from_in.Items.Count != 0)
				//    &&
				//    (from_in.Items[0].Value == "")
				//)
			) {
				bind_pre(
					allowNull_in
				);
			} else {
				listitemcollection_ref_.Clear();
			}

			for (int i = 0; i < from_in.Items.Count; i++) {
				if (from_in.Items[i].Value == "") continue;

				listitemcollection_ref_.Add(
//// already present at source, hence comment:
//#if DEBUG
//                    string.Format(
//                        "{0} ({1})", 
//                        from_in.Items[i].Text,
//                        from_in.Items[i].Value
//                    ), 
//#else
					from_in.Items[i].Text,
//#endif
					from_in.Items[i].Value
				);
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		#region public void Bind__Dictionary<TKey, TValue>(...);
		public delegate string DictionaryTextDelegate<TKey, TValue>(
			KeyValuePair<TKey, TValue> keyValuePair_in
		);

		public void Bind__Dictionary<TKey, TValue>(
			string selectedValue_in,
			bool allowNull_in,

			bool sortByName_in,

			Dictionary<TKey, TValue> enums_in,

			DictionaryTextDelegate<TKey, TValue> dictionaryText_in
		) {
			List<KeyValuePair<TKey, TValue>> _penums
				= new List<KeyValuePair<TKey, TValue>>(
					enums_in
				);

			if (sortByName_in) {
				_penums.Sort(
					delegate(
						KeyValuePair<TKey, TValue> arg1,
						KeyValuePair<TKey, TValue> arg2
					) {
						return (dictionaryText_in(arg1).CompareTo(dictionaryText_in(arg2)));
					}
				);
			}

			bind_pre(
				allowNull_in
			);

			foreach (KeyValuePair<TKey, TValue> _penum in _penums) {
				listitemcollection_ref_.Add(
					dictionaryText_in(_penum),
					_penum.Key.ToString()
				);
			}

			SelectedValue__set(
				selectedValue_in
			);
		}
		#endregion

		#region public string Text_get(string value_in);
		public string Text_get(string value_in) {
			for (int i = 0; i < listitemcollection_ref_.Count; i++) {
				if (listitemcollection_ref_[i].Value == value_in) {
					return listitemcollection_ref_[i].Text;
				}
			}

			return "";
		} 
		#endregion

		//#region public void Bind__PseudoEnum(...);
		//public void Bind__PseudoEnum(
		//    string selectedValue_in,
		//    bool allowNull_in,

		//    bool sortByName_in,

		//    Dictionary<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem> enums_in
		//) {
		//    List<KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem>> _penums
		//        = new List<KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem>>(
		//            enums_in
		//        );

		//    if (sortByName_in) {
		//        _penums.Sort(
		//            delegate(
		//                KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem> arg1,
		//                KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem> arg2
		//            ) {
		//                return (arg1.Value.Name.CompareTo(arg2.Value.Name));
		//            }
		//        );
		//    }

		//    bind_pre(
		//        allowNull_in
		//    );

		//    foreach (KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.PseudoEnumItem> _penum in _penums) {
		//        listitemcollection_ref_.Add(
		//            _penum.Value.Name,
		//            _penum.Key.ToString()
		//        );
		//    }

		//    SelectedValue__set(
		//        selectedValue_in
		//    );
		//}
		//#endregion
		//#region public void Bind__ErrorItem(...);
		//public void Bind__ErrorItem(
		//    string selectedValue_in,
		//    bool allowNull_in,

		//    bool sortByName_in,

		//    Dictionary<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem> enums_in
		//) {
		//    List<KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem>> _penums
		//        = new List<KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem>>(
		//            enums_in
		//        );

		//    if (sortByName_in) {
		//        _penums.Sort(
		//            delegate(
		//                KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem> arg1,
		//                KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem> arg2
		//            ) {
		//                return (arg1.Value.Name.CompareTo(arg2.Value.Name));
		//            }
		//        );
		//    }

		//    bind_pre(
		//        allowNull_in
		//    );

		//    foreach (KeyValuePair<int, AddSolutions.Kick.lib.businesslayer.shared.ErrorItem> _penum in _penums) {
		//        listitemcollection_ref_.Add(
		//            _penum.Value.Name,
		//            _penum.Key.ToString()
		//        );
		//    }

		//    SelectedValue__set(
		//        selectedValue_in
		//    );
		//}
		//#endregion
	}
}