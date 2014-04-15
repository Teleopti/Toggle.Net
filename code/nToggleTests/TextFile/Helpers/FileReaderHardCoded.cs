using nToggle.Providers.TextFile;

namespace nToggleTests.TextFile.Helpers
{
	public class FileReaderHardCoded : IFileReader
	{
		private readonly string[] _content;

		public FileReaderHardCoded(string[] content)
		{
			_content = content;
		}

		public string[] Content()
		{
			return _content;
		}
	}
}