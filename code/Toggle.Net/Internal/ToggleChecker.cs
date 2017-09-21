using System.Collections.Generic;
using Toggle.Net.Configuration;
using Toggle.Net.Providers;
using Toggle.Net.Specifications;

namespace Toggle.Net.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureProvider _featureProvider;
		private readonly IToggleSpecification _defaultToggleSpecification;
		private readonly IUserProvider _userProvider;

		internal ToggleChecker(IFeatureProvider featureProvider, IToggleSpecification defaultToggleSpecification, IUserProvider userProvider)
		{
			_featureProvider = featureProvider;
			_defaultToggleSpecification = defaultToggleSpecification;
			_userProvider = userProvider;
		}

		public bool IsEnabled(string toggleName)
		{
			var feature = _featureProvider.Get(toggleName);
			var currentUser = _userProvider.CurrentUser();
			return feature?.IsEnabled(currentUser) ?? _defaultToggleSpecification.IsEnabled(currentUser, new Dictionary<string, string>());
		}
	}
}