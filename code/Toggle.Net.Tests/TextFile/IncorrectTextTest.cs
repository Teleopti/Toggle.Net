using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile
{
	public class IncorrectTextTest
	{
		[Test]
		public void ShouldContainEqualSign()
		{
			var content = new[] { "someflag2" };
			Assert.Throws<IncorrectTextFileException>(() =>
					new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create()
				).ToString()
				.Should().Contain(string.Format(FileProviderFactory.MustContainEqualSign, 1));
		}

		[Test]
		public void ShouldNotContainMoreThanOneEqualSign()
		{
			var content = new[] { "someflag=true=true" };
			Assert.Throws<IncorrectTextFileException>(() =>
					new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create()
				).ToString()
				.Should().Contain(string.Format(FileProviderFactory.MustOnlyContainOneEqualSign, 1));
		}

		[Test]
		public void ShouldReturnAllExceptions()
		{
			var content = new[]
			{
				"missingEqual",
				"multipleEqual=false=true"
			};
			var ex = Assert.Throws<IncorrectTextFileException>(() =>
					new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create()
				).ToString();
			ex.Should().Contain(string.Format(FileProviderFactory.MustContainEqualSign, 1));
			ex.Should().Contain(string.Format(FileProviderFactory.MustOnlyContainOneEqualSign, 2));
		}

		[Test]
		public void ShouldContainValidSpecification()
		{
			var content = new[] { "someflag=maybe" };
			Assert.Throws<IncorrectTextFileException>(() =>
					new ToggleConfiguration(new FileProviderFactory(new FileReaderStub(content), new DefaultSpecificationMappings())).Create()
				).ToString()
				.Should().Contain(string.Format(FileProviderFactory.MustHaveValidSpecification, "maybe", 1));
		}
	}
}