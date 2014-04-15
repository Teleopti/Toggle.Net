using nToggle.Internal;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.TextFile
{
	public class TrueShortcutTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[] { "someflag=true" };
			var toggleChecker = new ToggleChecker(new FileProviderForTest(content));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}