using System.Collections.Generic;

namespace nToggle
{
	public class InMemoryConfiguration
	{
		private readonly ICollection<string> _configFlags;

		public InMemoryConfiguration()
		{
			_configFlags = new List<string>();
		}

		public void Enable(string configFlag)
		{
			_configFlags.Add(configFlag);
		}

		public IEnumerable<string> Metadata()
		{
			return _configFlags;
		}
	}
}