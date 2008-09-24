// Copyright (C) 2002 Francisco Monteiro

using System;

namespace OGen.UTs.howtos {
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
}