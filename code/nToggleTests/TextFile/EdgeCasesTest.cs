using nToggle.Internal;
using nToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.TextFile
{
	public class EdgeCasesTest
	{
		[Test]
		public void ShouldFindSpecificationWithWrongCasing()
		{
			var content = new[] { "someflag=TrUE" };
			var toggleChecker = new ToggleChecker(new FileProviderForTest(content));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindFlagWithWrongCasing()
		{
			var content = new[] { "SOMEfLAg=true" };
			var toggleChecker = new ToggleChecker(new FileProviderForTest(content));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

	}
}