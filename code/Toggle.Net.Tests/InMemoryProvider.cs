using System.Collections.Generic;
using System.Linq;
using Toggle.Net.Internal;
using Toggle.Net.Providers;

namespace Toggle.Net.Tests
{
	public class InMemoryProvider : IFeatureProviderFactory
	{
		private readonly IDictionary<string, Feature> _features;

		public InMemoryProvider(params Feature[] features)
		{
			_features = features.ToDictionary(x => x.FlagName);
		}
		
		public IFeatureProvider Create()
		{
			return new StaticFeatureProvider(_features);
		}
	}
}