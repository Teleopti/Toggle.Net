using nToggle.Internal;
using nToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.TextFile
{
	public class MultipleSpecificationTests
	{
		[Test]
		public void ShouldBeDisabled()
		{
			var content = new[]
			{
				"someflag=false",
				"someflag=true"
			};
			var toggleChecker = new ToggleChecker(new FileProviderForTest(content));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.False();
		}

	}
}