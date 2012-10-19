﻿#region Copyright (C) 2002 Francisco Monteiro
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
using System.Text;

namespace OGen.lib.worker {

	/// <summary>
	/// Worker class
	/// </summary>
	public class Worker {

		private object WorkLocker = new object();

		/// <summary>
		/// used to verify that work item is ready to work (check any priority rule)
		/// </summary>
		/// <typeparam name="T">type of work item</typeparam>
		/// <param name="workItem">work item</param>
		/// <returns></returns>
		public delegate bool IsReadyToWork<T>(T workItem);

		/// <summary>
		/// fired when work item is ready to do work
		/// </summary>
		/// <typeparam name="T">type of work item</typeparam>
		/// <param name="workItem">work item</param>
		public delegate void MakeItWork<T>(T workItem);

		/// <summary>
		/// fired when current thread finishes work (other threads may still be doing work)
		/// </summary>
		/// <param name="othersStillWorking_in">true if all threads finished work, false some still doing work</param>
		/// <returns></returns>
		public delegate bool ThreadFinished(bool othersStillWorking_in);

		/// <summary>
		/// method to be invoked when thread begins executing
		/// </summary>
		/// <typeparam name="T">type of work item</typeparam>
		/// <param name="workItems_in">work items list</param>
		/// <param name="isReadyToWork_in">used to verify that work item is ready to work (check any priority rule)</param>
		/// <param name="makeItWork_in">fired when work item is ready to do work</param>
		/// <param name="threadFinished_in">optional, fired when current thread finishes work (other threads may still be doing work)</param>
		/// <returns></returns>
		public bool DoWork<T>(
			System.Collections.Generic.List<WorkItem<T>> workItems_in,
			IsReadyToWork<T> isReadyToWork_in,
			MakeItWork<T> makeItWork_in,

			ThreadFinished threadFinished_in = null
		) {
			WorkItem<T> _item = null;
			lock (WorkLocker) {

				bool _othersstillworking = true;
				_item = null;
				for (int i = 0; i < workItems_in.Count; i++) {
					if (
						(workItems_in[i].State == WorkItemState.Waiting)
						&&
						isReadyToWork_in(workItems_in[i].Item) // ask again
					) {
						workItems_in[i].State = WorkItemState.Ready;
					}

					if (workItems_in[i].State == WorkItemState.Ready) {
						_item = workItems_in[i];
						_othersstillworking = false;
						break;
					} else if (workItems_in[i].State == WorkItemState.Doing) {
						_othersstillworking = false;
					}
				}

				if (_item == null) {
					if (threadFinished_in != null) {
						threadFinished_in(_othersstillworking);
					}

					return _othersstillworking;
				}

				_item.State = WorkItemState.Doing;
			}

			makeItWork_in(_item.Item);
			_item.State = WorkItemState.Done;

			return DoWork<T>(
				workItems_in,
				isReadyToWork_in,
				makeItWork_in
			);
		}
	}
}