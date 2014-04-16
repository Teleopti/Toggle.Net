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

			var nToggle = new ToggleChecker(new InMemoryProvider(
				new Feature(flag, new TrueSpecification())
			));

			nToggle.IsEnabled(flag)
				.Should().Be.True();
		}
	}
}