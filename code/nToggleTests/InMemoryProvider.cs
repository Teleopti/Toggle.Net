using System.Collections;
using System.Collections.Generic;
using nToggle.Internal;
using nToggle.Providers;

namespace nToggleTests
{
	public class InMemoryProvider : IFeatureProvider, IEnumerable<Feature>
	{
		private readonly IDictionary<string, Feature> _features;

		public InMemoryProvider()
		{
			_features = new Dictionary<string, Feature>();
		}

		public void Add(Feature feature)
		{
			_features.Add(feature.FlagName, feature);
		}

		public Feature Get(string flagName)
		{
			Feature feature;
			return _features.TryGetValue(flagName, out feature) ? feature : null;
		}

		public IEnumerator<Feature> GetEnumerator()
		{
			return _features.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}