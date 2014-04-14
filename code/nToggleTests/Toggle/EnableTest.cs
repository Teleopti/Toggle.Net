using System.Collections.Generic;
using nToggle.Configuration.Specifications;
using nToggle.Internal;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.Toggle
{
	public class EnableTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			const string flag = "someFlag";

			var nToggle = new ToggleChecker(new HashSet<Feature>
			{
				new Feature(flag, new TrueSpecification())
			});

			nToggle.IsEnabled(flag)
				.Should().Be.True();
		}
	}
}