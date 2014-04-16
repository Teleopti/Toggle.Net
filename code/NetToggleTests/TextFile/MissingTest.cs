using NetToggle.Internal;
using NetToggle.Providers.TextFile;
using NetToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.TextFile
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