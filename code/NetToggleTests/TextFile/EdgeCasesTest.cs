using NetToggle.Internal;
using NetToggle.Providers.TextFile;
using NetToggleTests.TextFile.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.TextFile
{
	public class EdgeCasesTest
	{
		[Test]
		public void ShouldFindSpecificationWithWrongCasing()
		{
			var content = new[] { "someflag=TrUE" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindFlagWithWrongCasing()
		{
			var content = new[] { "SOMEfLAg=true" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindUntrimmedFlag()
		{
			var content = new[] { "   someflag					  =true" };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindUntrimmedSpecification()
		{
			var content = new[] { "someflag=         true		  " };
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReaderHardCoded(content)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}