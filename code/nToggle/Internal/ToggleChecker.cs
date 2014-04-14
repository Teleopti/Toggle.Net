using System.Collections.Generic;
using System.Linq;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		public ToggleChecker(ISet<Feature> metadata)
		{
			Features = metadata.ToDictionary(x => x.FlagName);
		}

		public IDictionary<string, Feature> Features { get; private set; }

		public bool IsEnabled(string flagName)
		{
			Feature feature;
			return Features.TryGetValue(flagName, out feature) && feature.IsEnabled();
		}
	}
}