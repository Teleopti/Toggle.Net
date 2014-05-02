using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile
{
	public class MultipleParametersTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[]
			{
				"someflag=ParametersSpecification",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName1 + "=true",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName2 + "=true",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName3 + "=true"
			};
			var fileProvider = new FileProvider(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithMultipleParameters());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[]
			{
				"someflag=ParametersSpecification",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName1 + "=true",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName2 + "=false",
				"someflag.ParametersSpecification." + SpecificationWithMultipleParameters.ParameterName3 + "=true"
			};
			var fileProvider = new FileProvider(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithMultipleParameters());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}  
	}
}