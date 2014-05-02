using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.TextFile.Helpers;

namespace Toggle.Net.Tests.TextFile
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
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderHardCoded(content))).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}
	}
}