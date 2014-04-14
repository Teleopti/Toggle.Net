using System.Collections.Generic;
using System.Linq;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IDictionary<string, Feature> _metadata;

		public ToggleChecker(IEnumerable<Feature> metadata)
		{
			_metadata = metadata.ToDictionary(x => x.Flag);
		}

		public bool IsEnabled(string confligFlag)
		{
			Feature feature;
			return _metadata.TryGetValue(confligFlag, out feature) && feature.IsEnabled();
		}
	}
}