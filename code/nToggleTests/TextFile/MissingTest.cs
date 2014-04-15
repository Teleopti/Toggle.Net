using nToggle.Internal;
using nToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.TextFile
{
	public class MissingTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[] { "someflag=true" };
			var toggleChecker = new ToggleChecker(new FileProviderForTest(content));
			toggleChecker.IsEnabled("someflag2")
				.Should().Be.False();
		} 
	}
}