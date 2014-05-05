using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

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
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}
	}
}