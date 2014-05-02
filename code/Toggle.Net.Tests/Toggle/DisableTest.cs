using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Internal;
using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.Toggle
{
	public class DisableTest
	{
		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "someFlag";

			var toggle = new ToggleConfiguration(new InMemoryProvider(
				new Feature(flag, new FalseSpecification())
			)).Create();

			toggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisableIfAnySpecificationReturnFalse()
		{
			const string flag = "someFlag";

			var feature = new Feature(flag, new FalseSpecification());
			feature.AddSpecification(new TrueSpecification());

			var toggle = new ToggleConfiguration(new InMemoryProvider(feature)).Create();

			toggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisabledIfNotDefined()
		{
			var toggle = new ToggleConfiguration(new InMemoryProvider()).Create();

			toggle.IsEnabled("non existing")
				.Should().Be.False();
		}
	}
}