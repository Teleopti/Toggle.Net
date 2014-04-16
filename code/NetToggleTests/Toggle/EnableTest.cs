using NetToggle.Internal;
using NetToggle.Specifications;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.Toggle
{
	public class EnableTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			const string flag = "someFlag";

			var toggle = new ToggleChecker(new InMemoryProvider(
				new Feature(flag, new TrueSpecification())
			));

			toggle.IsEnabled(flag)
				.Should().Be.True();
		}
	}
}