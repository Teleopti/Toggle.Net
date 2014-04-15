using System.IO;

namespace nToggle.Providers.TextFile
{
	public class ContentReader : IContentReader
	{
		private readonly string _path;

		public ContentReader(string path)
		{
			_path = path;
		}

		public string[] Content()
		{
			return File.ReadAllLines(_path);
		}
	}
}