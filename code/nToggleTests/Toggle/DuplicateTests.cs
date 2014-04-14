using System.Collections.Generic;
using nToggle.Internal;
using nToggle.Specifications;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.Toggle
{
	public class DuplicateTests
	{
		[Test]
		public void ShouldOnlyAllowOneFeatureWithSameFlag()
		{
			const string flag = "someFlag";

			new ToggleChecker(new HashSet<Feature>
				{
					new Feature(flag, new FalseSpecification()),
					new Feature(flag, new FalseSpecification())
				}).Features.Count
			.Should().Be.EqualTo(1);
		}
	}
}