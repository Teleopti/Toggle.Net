using Toggle.Net.Internal;
using Toggle.Net.Providers;

namespace Toggle.Net.Configuration
{
	public class ToggleConfiguration
	{
		private readonly IFeatureProviderFactory _featureProviderFactory;
		private IUserProvider _userProvider;

		public ToggleConfiguration(IFeatureProviderFactory featureProviderFactory)
		{
			_featureProviderFactory = featureProviderFactory;
		}

		public ToggleConfiguration SetUserProvider(IUserProvider userProvider)
		{
			_userProvider = userProvider;
			return this;
		}

		public IToggleChecker Create()
		{
			if (_userProvider == null)
			{
				_userProvider = new NullUserProvider();
			}
			var featureProvider = _featureProviderFactory.Create();
			var ret = new ToggleChecker(featureProvider);
			ret.SetUserProvider(_userProvider);
			return ret;
		}
	}
}