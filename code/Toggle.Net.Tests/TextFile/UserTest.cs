using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile
{
	public class UserTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.id=roger"
			};
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content)))
				.SetUserProvider(new UserProviderStub("roger"))
				.Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.id=pelle"
			};
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content)))
				.SetUserProvider(new UserProviderStub("roger"))
				.Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		} 
	}
}