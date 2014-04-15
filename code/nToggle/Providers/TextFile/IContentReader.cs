namespace nToggle.Providers.TextFile
{
	public interface IContentReader
	{
		string[] Content(string path);
	}
}