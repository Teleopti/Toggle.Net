using System.Collections.Generic;
using System.Linq;
using Toggle.Net.Internal;

namespace Toggle.Net.Providers.InMemory
{
	public class InMemoryProviderFactory : IFeatureProviderFactory
	{
		private readonly IDictionary<string, Feature> _features;

		public InMemoryProviderFactory(params Feature[] features)
		{
			_features = features.ToDictionary(x => x.FlagName);
		}
		
		public IFeatureProvider Create()
		{
			return new StaticFeatureProvider(_features);
		}
	}
}