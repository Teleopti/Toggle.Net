using nToggle.Providers.TextFile;

namespace nToggleTests.TextFile
{
	public class FileProviderForTest : FileProvider
	{
		private readonly string[] _content;

		public FileProviderForTest(string[] content) : base(string.Empty)
		{
			_content = content;
		}

		protected override IContentReader ReadContent()
		{
			return new contentReader(_content);
		}

		private class contentReader : IContentReader
		{
			private readonly string[] _content;

			public contentReader(string[] content)
			{
				_content = content;
			}

			public string[] Content(string path)
			{
				return _content;
			}
		}
	}
}