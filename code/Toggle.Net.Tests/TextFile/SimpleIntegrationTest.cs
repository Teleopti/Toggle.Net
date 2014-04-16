using System.IO;
using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;

namespace Toggle.Net.Tests.TextFile
{
	public class SimpleIntegrationTest
	{
		private string tempPath;

		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[] {"someflag=true"};
			tempPath = Path.GetTempFileName();
			File.WriteAllLines(tempPath, content);
			var toggleChecker = new ToggleChecker(new FileProvider(new FileReader(tempPath)));
			toggleChecker.IsEnabled("someflag")
				.Should().Be.True();
		}
		
		[SetUp]
		public void CreateFile()
		{
			tempPath = Path.GetTempFileName();
		}

		[TearDown]
		public void DropFile()
		{
			File.Delete(tempPath);
		}
	}
}