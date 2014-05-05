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

		public bool IsEnabled(string toggleName)
		{
			var feature = _featureProvider.Get(toggleName);
			return feature != null && feature.IsEnabled(_userProvider.CurrentUser());
		}
	}
}