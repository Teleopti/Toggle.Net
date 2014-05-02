using System;
using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Internal;
using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.Toggle
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

		[Test]
		public void ShouldNotHaveDotsInItsName()
		{
			Assert.Throws<ArgumentException>(() =>
				new Feature("flag.name", new FalseSpecification())
			).ToString()
			.Should().Contain(Feature.FlagNameMustNotContainDots);
		}
	}
}