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
using System.Collections.Generic;
using System.Text;

namespace OGen.NTier.Kick.lib.businesslayer.shared {
	public class PermitionType {
		protected static readonly Dictionary<int, PseudoEnumItem> items_;

		static PermitionType() {
			items_ = new Dictionary<int, PseudoEnumItem>();
			items_.Add(User__select, new PseudoEnumItem("User - select"));
			items_.Add(User__insert, new PseudoEnumItem("User - insert"));
			items_.Add(User__update, new PseudoEnumItem("User - update"));
			items_.Add(User__delete, new PseudoEnumItem("User - delete"));
			items_.Add(Log__mark_read, new PseudoEnumItem("Log - mark read"));
			items_.Add(Profile__select, new PseudoEnumItem("Profile - select"));
			items_.Add(Profile__insert, new PseudoEnumItem("Profile - insert"));
			items_.Add(Profile__update, new PseudoEnumItem("Profile - update"));
			items_.Add(Profile__delete, new PseudoEnumItem("Profile - delete"));
			items_.Add(Log__read, new PseudoEnumItem("Log - read"));
			items_.Add(Permition__select, new PseudoEnumItem("Permition - select"));
			items_.Add(News__delete_Approved, new PseudoEnumItem("News - delete Approved"));
			items_.Add(News__delete_Mine_notApproved, new PseudoEnumItem("News - delete Mine notApproved"));
			items_.Add(News__insert, new PseudoEnumItem("News - insert"));
			items_.Add(News__update_Approved, new PseudoEnumItem("News - update Approved"));
			items_.Add(News__update_Mine_notApproved, new PseudoEnumItem("News - update Mine notApproved"));
			items_.Add(News__select_OnSchedule, new PseudoEnumItem("News - select OnSchedule"));
			items_.Add(News__select_OffSchedule, new PseudoEnumItem("News - select OffSchedule"));
			items_.Add(News__approve, new PseudoEnumItem("News - approve"));
			items_.Add(Tag__select, new PseudoEnumItem("Tag - select"));
			items_.Add(Tag__select_notApproved, new PseudoEnumItem("Tag - select notApproved"));
			items_.Add(Highlight__select, new PseudoEnumItem("Highlight - select"));
			items_.Add(Highlight__select_notApproved, new PseudoEnumItem("Highlight - select notApproved"));
			items_.Add(Source__select, new PseudoEnumItem("Source - select"));
			items_.Add(Source__select_notApproved, new PseudoEnumItem("Source - select notApproved"));
			items_.Add(Author__select, new PseudoEnumItem("Author - select"));
			items_.Add(Author__select_notApproved, new PseudoEnumItem("Author - select notApproved"));
			items_.Add(News__Profile__select, new PseudoEnumItem("News - Profile - select"));
			items_.Add(News__Profile__insert, new PseudoEnumItem("News - Profile - insert"));
			items_.Add(News__Profile__update, new PseudoEnumItem("News - Profile - update"));
			items_.Add(News__Profile__delete, new PseudoEnumItem("News - Profile - delete"));
			items_.Add(Author__insert, new PseudoEnumItem("Author - insert"));
			items_.Add(Author__update, new PseudoEnumItem("Author - update"));
			items_.Add(Author__approve, new PseudoEnumItem("Author - approve"));
			items_.Add(Author__delete, new PseudoEnumItem("Author - delete"));
			items_.Add(Highlight__insert, new PseudoEnumItem("Highlight - insert"));
			items_.Add(Highlight__update, new PseudoEnumItem("Highlight - update"));
			items_.Add(Highlight__approve, new PseudoEnumItem("Highlight - approve"));
			items_.Add(Highlight__delete, new PseudoEnumItem("Highlight - delete"));
			items_.Add(Source__insert, new PseudoEnumItem("Source - insert"));
			items_.Add(Source__update, new PseudoEnumItem("Source - update"));
			items_.Add(Source__approve, new PseudoEnumItem("Source - approve"));
			items_.Add(Source__delete, new PseudoEnumItem("Source - delete"));
			items_.Add(News__Profile__approve, new PseudoEnumItem("News - Profile - approve"));
			items_.Add(Tag__insert, new PseudoEnumItem("Tag - insert"));
			items_.Add(Tag__update, new PseudoEnumItem("Tag - update"));
			items_.Add(Tag__approve, new PseudoEnumItem("Tag - approve"));
			items_.Add(Tag__delete, new PseudoEnumItem("Tag - delete"));
			items_.Add(Forum__Forum__read, new PseudoEnumItem("Forum - Forum - read"));
			items_.Add(Forum__Thread__read, new PseudoEnumItem("Forum - Thread - read"));
			items_.Add(Forum__Reply__read, new PseudoEnumItem("Forum - Reply - read"));
			items_.Add(Forum__Forum__delete, new PseudoEnumItem("Forum - Forum - delete"));
			items_.Add(Forum__Thread__delete, new PseudoEnumItem("Forum - Thread - delete"));
			items_.Add(Forum__Reply__delete, new PseudoEnumItem("Forum - Reply - delete"));
			items_.Add(Forum__Thread__insert, new PseudoEnumItem("Forum - Thread - insert"));
			items_.Add(Forum__Reply__insert, new PseudoEnumItem("Forum - Reply - insert"));
			items_.Add(Forum__Forum__insert, new PseudoEnumItem("Forum - Forum - insert"));

		}

		public const int User__select = 1;
		public const int User__insert = 2;
		public const int User__update = 3;
		public const int User__delete = 4;

		public const int Log__mark_read = 5;
		public const int Log__read = 10;

		public const int Profile__select = 6;
		public const int Profile__insert = 7;
		public const int Profile__update = 8;
		public const int Profile__delete = 9;

		public const int Permition__select = 11;

		public const int News__delete_Approved = 12;
		public const int News__delete_Mine_notApproved = 13;
		public const int News__insert = 14;
		public const int News__update_Approved = 15;
		public const int News__update_Mine_notApproved = 16;
		public const int News__select_OnSchedule = 17;
		public const int News__select_OffSchedule = 18;
		public const int News__approve = 19;

		public const int Tag__select = 20;
		public const int Tag__select_notApproved = 21;
		public const int Tag__insert = 45;
		public const int Tag__update = 46;
		public const int Tag__approve = 47;
		public const int Tag__delete = 48;

		public const int Highlight__select = 22;
		public const int Highlight__select_notApproved = 23;
		public const int Highlight__insert = 36;
		public const int Highlight__update = 37;
		public const int Highlight__approve = 38;
		public const int Highlight__delete = 39;

		public const int Source__select = 24;
		public const int Source__select_notApproved = 25;
		public const int Source__insert = 40;
		public const int Source__update = 41;
		public const int Source__approve = 42;
		public const int Source__delete = 43;

		public const int Author__select = 26;
		public const int Author__select_notApproved = 27;
		public const int Author__insert = 32;
		public const int Author__update = 33;
		public const int Author__approve = 34;
		public const int Author__delete = 35;

		public const int News__Profile__select = 28;
		public const int News__Profile__insert = 29;
		public const int News__Profile__update = 30;
		public const int News__Profile__delete = 31;
		public const int News__Profile__approve = 44;

		public const int Forum__Forum__read = 49;
		public const int Forum__Thread__read = 50;
		public const int Forum__Reply__read = 51;
		public const int Forum__Forum__delete = 52;
		public const int Forum__Thread__delete = 53;
		public const int Forum__Reply__delete = 54;
		public const int Forum__Thread__insert = 55;
		public const int Forum__Reply__insert = 56;
		public const int Forum__Forum__insert = 57;

	}
}