using System.Collections.Generic;
using System.Linq;
using NetToggle.Internal;
using NetToggle.Providers;

namespace NetToggleTests
{
	public class InMemoryProvider : IFeatureProvider
	{
		private readonly IDictionary<string, Feature> _features;

		public InMemoryProvider(params Feature[] features)
		{
			_features = features.ToDictionary(x => x.FlagName);
		}

		public Feature Get(string flagName)
		{
			Feature feature;
			return _features.TryGetValue(flagName, out feature) ? feature : null;
		}
	}
}