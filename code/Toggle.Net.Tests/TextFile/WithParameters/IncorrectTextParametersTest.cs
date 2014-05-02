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
			var fileProvider = new FileProviderFactory(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());

			Assert.Throws<IncorrectTextFileException>(() =>
				new ToggleConfiguration(fileProvider).Create()
				).ToString()
				.Should().Contain(string.Format(FileProviderFactory.MustHaveTwoDotsIfParameterUse, 2));
		}

		[Test]
		public void ShouldThrowIfParameterIsUsedAndMoreThanTwoDotsExist()
		{
			var content = new[]
			{
				"myfeature=ParameterSpecification",
				"myfeature.ParameterSpecification.three.four=true"
			};
			var fileProvider = new FileProviderFactory(new FileReaderStub(content));
			fileProvider.AddSpecification(new SpecificationWithParameter());

			Assert.Throws<IncorrectTextFileException>(() =>
				new ToggleConfiguration(fileProvider).Create()
				).ToString()
				.Should().Contain(string.Format(FileProviderFactory.MustHaveTwoDotsIfParameterUse, 2));
		}
	}
}