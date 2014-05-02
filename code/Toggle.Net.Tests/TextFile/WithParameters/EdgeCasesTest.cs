using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile.WithParameters
{
	public class EdgeCasesTest
	{
		[Test]
		public void ShouldFindParameterWithWrongCasing()
		{
			var content = new[]
			{
				"someflag=ParameterSpecification",
				"someflag.ParameterSpecification." + SpecificationWithParameter.ParameterName.ToUpper() + "=true"
			};
			var fileProvider = new FileProviderFactory(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}