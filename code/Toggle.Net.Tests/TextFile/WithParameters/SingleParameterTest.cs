using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile.WithParameters
{
	public class SingleParameterTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[]
			{
				"someflag=ParameterSpecification",
				"someflag.ParameterSpecification." + SpecificationWithParameter.ParameterName + "=true"
			};
			var fileProvider = new FileProviderFactory(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[]
			{
				"someflag=ParameterSpecification",
				"someflag.ParameterSpecification." + SpecificationWithParameter.ParameterName + "=false"
			};
			var fileProvider = new FileProviderFactory(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		} 
	}
}