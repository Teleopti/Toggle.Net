using Toggle.Net.Configuration;

namespace Toggle.Net.Internal
{
	public class NullUserProvider : IUserProvider
	{
		public string CurrentUser()
		{
			return string.Empty;
		}
	}
}