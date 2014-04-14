using System.Collections.Generic;

namespace nToggle.Configuration
{
	public class InMemoryConfiguration
	{
		private readonly ICollection<string> _configFlags;

		public InMemoryConfiguration()
		{
			_configFlags = new List<string>();
		}

		public void Enable(string flag)
		{
			_configFlags.Add(flag);
		}

		public IEnumerable<string> Metadata()
		{
			return _configFlags;
		}
	}
}