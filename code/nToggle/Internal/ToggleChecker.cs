using System.Collections.Generic;
using System.Linq;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IDictionary<string, Feature> _metadata;

		public ToggleChecker(IEnumerable<Feature> metadata)
		{
			_metadata = metadata.ToDictionary(x => x.FlagName);
		}

		public bool IsEnabled(string flagName)
		{
			Feature feature;
			return _metadata.TryGetValue(flagName, out feature) && feature.IsEnabled();
		}
	}
}