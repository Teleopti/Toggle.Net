using System;
using NetToggle.Internal;
using NetToggle.Specifications;
using NUnit.Framework;

namespace NetToggleTests.Toggle
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