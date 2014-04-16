using NetToggle.Internal;
using NetToggle.Providers.TextFile;
using NetToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.TextFile
{
	public class MultipleSpecificationTests
	{
		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[]
			{
				"someflag=false",
				"someflag=true"
			};
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}
	}
}