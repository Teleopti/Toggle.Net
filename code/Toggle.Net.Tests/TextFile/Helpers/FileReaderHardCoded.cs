using Toggle.Net.Providers.TextFile;

namespace Toggle.Net.Tests.TextFile.Helpers
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