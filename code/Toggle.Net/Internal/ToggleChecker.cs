using Toggle.Net.Configuration;
using Toggle.Net.Providers;

namespace Toggle.Net.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureProvider _featureProvider;
		private IUserProvider _userProvider;

		public ToggleChecker(IFeatureProvider featureProvider)
		{
			_featureProvider = featureProvider;
		}

		public bool IsEnabled(string flagName)
		{
			var feature = _featureProvider.Get(flagName);
			return feature != null && feature.IsEnabled(_userProvider.CurrentUser());
		}

		public void SetUserProvider(IUserProvider userProvider)
		{
			_userProvider = userProvider;
		}
	}
}