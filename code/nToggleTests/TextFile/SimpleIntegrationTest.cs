using System.IO;
using nToggle.Internal;
using nToggle.Providers.TextFile;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.TextFile
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
			var toggleChecker = new ToggleChecker(new FileProvider(new ContentReader(tempPath)));
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