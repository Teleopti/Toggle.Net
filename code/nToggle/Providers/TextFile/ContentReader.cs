using System.IO;

namespace nToggle.Providers.TextFile
{
	public class ContentReader : IContentReader
	{
		public string[] Content(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}