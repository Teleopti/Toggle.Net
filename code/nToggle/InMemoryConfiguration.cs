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

		public void Enable<T>(T feature) where T : IFeature
		{
			_configFlags.Add(feature.Flag);
		}

		public IEnumerable<string> Metadata()
		{
			return _configFlags;
		}
	}
}