using NetToggle.Internal;
using NetToggle.Specifications;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.Toggle
{
	public class DisableTest
	{
		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "someFlag";

			var nToggle = new ToggleChecker(new InMemoryProvider(
				new Feature(flag, new FalseSpecification())
			));

			nToggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisableIfAnySpecificationReturnFalse()
		{
			const string flag = "someFlag";

			var feature = new Feature(flag, new FalseSpecification());
			feature.AddSpecification(new TrueSpecification());

			var nToggle = new ToggleChecker(new InMemoryProvider(feature));

			nToggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisabledIfNotDefined()
		{
			var nToggle = new ToggleChecker(new InMemoryProvider());

			nToggle.IsEnabled("non existing")
				.Should().Be.False();
		}
	}
}