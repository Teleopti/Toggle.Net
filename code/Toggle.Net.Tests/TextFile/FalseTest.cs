using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile
{
	public class FalseTest
	{
		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[] { "someflag=false" };
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisabledIfNonExistingToggle()
		{
			var content = new[] { "someflag=true" };
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create();
			toggleChecker.IsEnabled("someflag2")
				.Should().Be.False();
		} 
	}
}