using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.TextFile.Helpers;

namespace Toggle.Net.Tests.TextFile
{
	public class EdgeCasesTest
	{
		[Test]
		public void ShouldFindSpecificationWithWrongCasing()
		{
			var content = new[] { "someflag=TrUE" };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderHardCoded(content))).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindFlagWithWrongCasing()
		{
			var content = new[] { "SOMEfLAg=true" };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderHardCoded(content))).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindUntrimmedFlag()
		{
			var content = new[] { "   someflag					  =true" };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderHardCoded(content))).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}

		[Test]
		public void ShouldFindUntrimmedSpecification()
		{
			var content = new[] { "someflag=         true		  " };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderHardCoded(content))).Create();
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
	}
}