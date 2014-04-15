using System;
using nToggle.Internal;
using nToggle.Specifications;
using NUnit.Framework;

namespace nToggleTests.Toggle
{
	public class IllegalFeatureStateTest
	{
		[Test]
		public void ShouldNotAcceptNullAsFeature()
		{
			Assert.Throws<ArgumentNullException>(() => 
				new Feature("theflag", null)
			);
		}

		[Test]
		public void ShouldNotAcceptNullWhenAddingFeature()
		{
			var feature = new Feature("theflag", new FalseSpecification());
			Assert.Throws<ArgumentNullException>(() =>
				feature.AddSpecification(null)
			);
		}
	}
}