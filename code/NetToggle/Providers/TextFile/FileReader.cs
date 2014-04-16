using System.IO;

namespace nToggle.Providers.TextFile
{
	public class FileReader : IFileReader
	{
		private readonly string _path;

		public FileReader(string path)
		{
			_path = path;
		}

		public string[] Content()
		{
			return File.ReadAllLines(_path);
		}
	}
}