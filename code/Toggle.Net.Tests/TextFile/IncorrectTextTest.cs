﻿using NUnit.Framework;
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
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content))).Create();
			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustContainEqualSign, 1));
		}

		[Test]
		public void ShouldNotContainMoreThanOneEqualSign()
		{
			var content = new[] { "someflag=true=true" };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content))).Create();
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
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content))).Create();
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
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content))).Create();
			Assert.Throws<IncorrectTextFileException>(() =>
				toggleChecker.IsEnabled("someflag")
					.Should().Be.False()
				).ToString()
				.Should().Contain(string.Format(FileProvider.MustHaveValidSpecification, "maybe", 1));
		}
	}
}