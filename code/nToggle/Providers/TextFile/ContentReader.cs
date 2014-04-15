using System.IO;

namespace nToggle.Providers.TextFile
{
	public class ReadContent : IReadContent
	{
		public string[] Content(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}