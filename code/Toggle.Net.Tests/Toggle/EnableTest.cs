using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Internal;
using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.Toggle
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