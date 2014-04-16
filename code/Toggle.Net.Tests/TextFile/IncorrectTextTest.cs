using NetToggle.Internal;
using NetToggle.Providers.TextFile;
using NetToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.TextFile
{
	public class IncorrectTextTest
	{
		[Test]
		public void ShouldContainEqualSign()
		{
			var content = new[] { "someflag2" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustContainEqualSign, 1));
		}

		[Test]
		public void ShouldNoContainMoreThanOneEqualSign()
		{
			var content = new[] { "someflag=true=true" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustOnlyContainOneEqualSign, 1));
		}

		[Test]
		public void ShouldReturnAllExceptions()
		{
			var content = new[]
			{
				"missingEqual",
				"multipleEqual=false=true"
			};
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			var ex = Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString();
			ex.Should().Contain(string.Format(FileProvider.MustContainEqualSign, 1));
			ex.Should().Contain(string.Format(FileProvider.MustOnlyContainOneEqualSign, 2));
		}

		[Test]
		public void ShouldContainValidSpecification()
		{
			var content = new[] { "someflag=maybe" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustHaveValidSpecification, "maybe", 1));
		}
	}
}