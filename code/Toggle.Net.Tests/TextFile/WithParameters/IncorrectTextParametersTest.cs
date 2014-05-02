using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile.WithParameters
{
	public class IncorrectTextParametersTest
	{
		[Test]
		public void ShouldThrowIfParameterIsUsedAndOnlyOneDotExist()
		{
			var content = new[]
			{
				"myfeature=ParameterSpecification",
				"myfeature.ParameterSpecification=true"
			};
			var fileProvider = new FileProvider(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();

			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustHaveTwoDotsIfParameterUse, 2));
		}

		[Test]
		public void ShouldThrowIfParameterIsUsedAndMoreThanTwoDotsExist()
		{
			var content = new[]
			{
				"myfeature=ParameterSpecification",
				"myfeature.ParameterSpecification.three.four=true"
			};
			var fileProvider = new FileProvider(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());
			var toggleChecker = new ToggleConfiguration(fileProvider).Create();

			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustHaveTwoDotsIfParameterUse, 2));
		}
	}
}