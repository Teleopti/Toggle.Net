using System.Collections.Generic;
using Toggle.Net.Configuration;
using Toggle.Net.Providers;
using Toggle.Net.Specifications;

namespace Toggle.Net.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureProvider _featureProvider;
		private readonly IToggleSpecification _defaulToggleSpecification;
		private readonly IUserProvider _userProvider;

		internal ToggleChecker(IFeatureProvider featureProvider, IToggleSpecification defaulToggleSpecification, IUserProvider userProvider)
		{
			_featureProvider = featureProvider;
			_defaulToggleSpecification = defaulToggleSpecification;
			_userProvider = userProvider;
		}

		public bool IsEnabled(string toggleName)
		{
			var feature = _featureProvider.Get(toggleName);
			var currentUser = _userProvider.CurrentUser();
			return feature == null ? 
					_defaulToggleSpecification.IsEnabled(currentUser, new Dictionary<string, string>()) : 
					feature.IsEnabled(currentUser);
		}
	}
}