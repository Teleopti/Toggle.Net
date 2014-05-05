using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Specifications;
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
				"someflag.user." + UserSpecification.Ids + "=10"
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("10"))
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
				"someflag.user." + UserSpecification.Ids + "=nope"
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("10"))
				.Create();

			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeEnabledIfExistsInParameterList()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.user." + UserSpecification.Ids + "=1,2,3,4"
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("2"))
				.Create();

			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}


		[Test]
		public void ShouldBeEnabledIfExistsInParameterListWithSpaces()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.user." + UserSpecification.Ids + " =   1, 2	,  3 ,4  "
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("2"))
				.Create();

			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldTreatIdsAsOneIfCurrentUserContainsComma_Disabled()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.user." + UserSpecification.Ids + "=1,2,3,4"
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("2,"))
				.Create();

			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}


		[Test]
		public void ShouldTreatIdsAsOneIfCurrentUserContainsComma_Enabled()
		{
			var content = new[]
			{
				"someflag=user",
				"someflag.user." + UserSpecification.Ids + "=  1,2,3,4  "
			};
			var toggleChecker = new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings()))
				.SetUserProvider(new UserProviderStub("1,2,3,4"))
				.Create();

			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}