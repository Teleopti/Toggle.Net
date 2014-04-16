using NetToggle.Internal;
using NetToggle.Providers.TextFile;
using NetToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.TextFile
{
	public class RemarkTest
	{
		[Test]
		public void ShouldBeAbleToWriteRemarks()
		{
			var content = new[]
			{
				"#this should not throw",
				"someflag=true",
				" # and neither should this"
			};
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldAllowBlankLines()
		{
			var content = new[]
			{
				"				 ",
				"someflag=true",
				"",
				string.Empty
			};
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}