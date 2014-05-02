using Toggle.Net.Internal;
using Toggle.Net.Providers;

namespace Toggle.Net.Configuration
{
	public class ToggleConfiguration
	{
		private readonly IFeatureProvider _featureProvider;
		private IUserProvider _userProvider;

		public ToggleConfiguration(IFeatureProvider featureProvider)
		{
			_featureProvider = featureProvider;
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
			var ret = new ToggleChecker(_featureProvider);
			ret.SetUserProvider(_userProvider);
			return ret;
		}
	}
}