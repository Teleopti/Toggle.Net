using nToggle.Internal;
using nToggle.Providers.TextFile;
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
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag2")
				.Should().Be.False();
		} 
	}
}