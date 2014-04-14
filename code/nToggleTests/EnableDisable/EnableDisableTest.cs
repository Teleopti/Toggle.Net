using System.Linq;
using nToggle.Configuration.Specifications;
using nToggle.Internal;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.EnableDisable
{
	public class EnableDisableTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			const string flag = "someFlag";

			var nToggle = new ToggleChecker(new[]
			{
				new Feature(flag, new TrueSpecification())
			});

			nToggle.IsEnabled(flag)
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "someFlag";

			var nToggle = new ToggleChecker(new[]
			{
				new Feature(flag, new FalseSpecification())
			});

			nToggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisableIfAnySpecificationReturnFalse()
		{
			const string flag = "someFlag";

			var nToggle = new ToggleChecker(new[]
			{
				new Feature(flag, new FalseSpecification(), new TrueSpecification())
			});

			nToggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisabledIfNotDefined()
		{
			var nToggle = new ToggleChecker(Enumerable.Empty<Feature>());

			nToggle.IsEnabled("non existing")
				.Should().Be.False();
		}
	}
}