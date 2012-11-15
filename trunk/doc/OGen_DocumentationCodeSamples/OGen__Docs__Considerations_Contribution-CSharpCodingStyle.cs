#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DocumentationCodeSamples.UnitTests {
	using System;
#if NUnit
	using NUnit.Framework;
#else
	using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

//<document>
public class SomeClass : IDisposable { // PascalCasing
	#region public SomeClass(...);
	public SomeClass(
		int someProperty_in // camelCasing
	) {
		this.somerarelyusedproperty__ = null;
		this.someproperty_ = someProperty_in;
	}
	~SomeClass() {
		this.Dispose(false);
	}
	#endregion

	#region public void Dispose(...);
	protected virtual void Dispose(bool disposing_in) {
		// check before lock
		if (this.somerarelyusedproperty__ != null) {

			lock (this.somerarelyusedproperty__locker) {

				// double check, thread safer!
				if (this.somerarelyusedproperty__ != null) {

					this.somerarelyusedproperty__.Dispose();
					this.somerarelyusedproperty__ = null;
				}
			}
		}
	}

	public void Dispose() {
		this.Dispose(true);
		System.GC.SuppressFinalize(this);
	}
	#endregion

	#region private properties...
	private int someotherproperty_; // lowercasing_
	#endregion
	#region public Properties...
	#region public int SomeProperty { get; set; }
	private int someproperty_; // lowercasing_

	public int SomeProperty { // PascalCasing
		get { return someproperty_; }
		set { someproperty_ = value; }
	}
	#endregion
	#region public SomeBigResourceConsumerClass SomeRarelyUsedProperty { get; }
	private SomeBigResourceConsumerClass somerarelyusedproperty__; // lowercasing__
	private object somerarelyusedproperty__locker = new object();

	public SomeBigResourceConsumerClass SomeRarelyUsedProperty { // PascalCasing
		get {

			// check before lock
			if (somerarelyusedproperty__ == null) {

				lock (somerarelyusedproperty__locker) {

					// double check, thread safer!
					if (somerarelyusedproperty__ == null) {

						// instantiating for the first time and
						// only because it became needed, otherwise
						// never instantiated...

						// initialization...
						// ...attribution (last thing before unlock)
						somerarelyusedproperty__ = new SomeBigResourceConsumerClass();
					}
				}
			}
			return somerarelyusedproperty__;
		}
	}
	#endregion
	#endregion

	#region private methods...
	#region private void someothermethod(...);
	private void someothermethod() { // lowercasing
		// some code...
	}
	#endregion
	#endregion
	#region public Methods...
	#region public int SomeMethod(...);
	private void somemethod_aux() {
		// some code...
	}

	public int SomeMethod( // PascalCasing
		int someParameter_in, // camelCasing
		out int someOtherParameter_out // camelCasing
	) {
		int SomeMethod_out = 0;
		char _auxvar; // _lowercasing

		// some code...
		someOtherParameter_out = 0;
		// some more code...

		return SomeMethod_out;
	}
	#endregion
	#endregion
}
//</document>

	public class SomeBigResourceConsumerClass : IDisposable { // PascalCasing
		public SomeBigResourceConsumerClass() {
			Disposed = false;
		}

		public void Dispose() {
			Disposed = true;	
		}

		public bool Disposed;
	}

#if NUnit
	[TestFixture]
#else
	[TestClass]
#endif
	public class Considerations_Contribution_CSharpCodingStyle {
		public Considerations_Contribution_CSharpCodingStyle() { }

#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void HowTo() {

			SomeClass _aux = new SomeClass(1);
			Assert.AreEqual(1, _aux.SomeProperty);

			SomeBigResourceConsumerClass _aux2 = _aux.SomeRarelyUsedProperty;
			Assert.IsNotNull(_aux2);

			int _aux3;
			_aux.SomeMethod(1, out _aux3);

			_aux.Dispose();
			Assert.IsTrue(_aux2.Disposed);

			// the only porpuses is to keep documentation code samples updated by: 
			// 1) ensure documentation code samples are compiling 
			// 2) no exceptions are beeing thrown by documentation code samples
			Assert.IsTrue(
				true,
				"documentation code sample is failing"
			);

		}
	}
}