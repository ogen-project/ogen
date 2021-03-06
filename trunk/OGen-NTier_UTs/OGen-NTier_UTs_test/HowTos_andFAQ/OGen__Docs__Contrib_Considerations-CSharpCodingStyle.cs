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

namespace OGen.UTs.howtos {
//<document>
public class SomeClass : IDisposable { // PascalCasing
	#region public SomeClass(...);
	public SomeClass(
		int someProperty_in // camelCasing
	) {
		somerarelyusedproperty__ = null;
		someproperty_ = someProperty_in;
	}
	#endregion
	#region ~SomeClass();
	~SomeClass() {
		cleanUp();
	}
	public void Dispose() {
		System.GC.SuppressFinalize(this);
		cleanUp();
	}
	private void cleanUp() {
		// some code...
		if (somerarelyusedproperty__ != null)
			somerarelyusedproperty__.Dispose();
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

	public SomeBigResourceConsumerClass SomeRarelyUsedProperty { // PascalCasing
		get {
			if (somerarelyusedproperty__ == null) {
				// instantiating for the first time and
				// only because it became needed, otherwise
				// never instantiated...
				somerarelyusedproperty__ = new SomeBigResourceConsumerClass();
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

public class SomeBigResourceConsumerClass : IDisposable { // PascalCasing
	public SomeBigResourceConsumerClass() {
		// some code...
	}
	public void Dispose() {
		// some code...
	}
}
//</document>
}