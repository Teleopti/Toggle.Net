using System.Collections.Generic;
using nToggle.Configuration.Specifications;
using nToggle.Internal;

namespace nToggle.Configuration
{
	public class InMemoryConfiguration
	{
		private readonly ICollection<Feature> _configFlags;

		public InMemoryConfiguration()
		{
			_configFlags = new List<Feature>();
		}

		public void Add(string flag, IToggleSpecification specification)
		{
			var feature = new Feature(flag);
			feature.AddSpecification(specification);
			_configFlags.Add(feature);
		}

		public IEnumerable<Feature> Metadata()
		{
			return _configFlags;
		}
	}
}