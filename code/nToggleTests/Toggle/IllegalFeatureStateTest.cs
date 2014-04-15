using System;
using nToggle.Internal;
using NUnit.Framework;

namespace nToggleTests.Toggle
{
	public class IllegalFeatureStateTest
	{
		[Test]
		public void ShouldNotAcceptNullAsFeature()
		{
			Assert.Throws<ArgumentNullException>(() => new ToggleChecker(new InMemoryProvider
						{
							new Feature("theflag", null)
						})
				);
		}
	}
}