using nToggle.Internal;
using nToggle.Providers.Memory;
using nToggle.Specifications;
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

			var nToggle = new ToggleChecker(new InMemoryProvider
			{
				new Feature(flag, new TrueSpecification())
			});

			nToggle.IsEnabled(flag)
				.Should().Be.True();
		}
	}
}