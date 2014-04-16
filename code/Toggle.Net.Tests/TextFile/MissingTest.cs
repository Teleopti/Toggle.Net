using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.TextFile.Helpers;

namespace Toggle.Net.Tests.TextFile
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