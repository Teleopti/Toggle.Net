using System;
using nToggle.Configuration.Specifications;
using nToggle.Internal;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.Toggle
{
	public class DuplicateTests
	{
		[Test]
		public void ShouldThrowIfMultipleFlagKeysAreFound()
		{
			const string flag = "someFlag";

			Assert.Throws<InvalidOperationException>(() =>
				new ToggleChecker(new[]
				{
					new Feature(flag, new FalseSpecification()),
					new Feature(flag, new FalseSpecification())
				})
			);
		}

		[Test]
		public void ShouldContainFlagNamesInExceptionMessage()
		{
			const string exFlag1 = "someExFlag";
			const string exFlag2 = "someEx2Flag";
			const string correctFlag = "someCorrectFlag";

			var exString = Assert.Throws<InvalidOperationException>(() =>
				new ToggleChecker(new[]
				{
					new Feature(exFlag1, new FalseSpecification()),
					new Feature(exFlag2, new FalseSpecification()),
					new Feature(correctFlag, new FalseSpecification()),
					new Feature(exFlag2, new FalseSpecification()),
					new Feature(exFlag1, new FalseSpecification()),

				})
			).ToString();

			exString.Should().Contain(exFlag1);
			exString.Should().Contain(exFlag2);
			exString.Should().Not.Contain(correctFlag);
		} 
	}
}