using Toggle.Net.Configuration;
using Toggle.Net.Providers;

namespace Toggle.Net.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureProvider _featureProvider;
		private readonly IUserProvider _userProvider;

		internal ToggleChecker(IFeatureProvider featureProvider, IUserProvider userProvider)
		{
			_featureProvider = featureProvider;
			_userProvider = userProvider;
		}

		public bool IsEnabled(string flagName)
		{
			var feature = _featureProvider.Get(flagName);
			return feature != null && feature.IsEnabled(_userProvider.CurrentUser());
		}
	}
}