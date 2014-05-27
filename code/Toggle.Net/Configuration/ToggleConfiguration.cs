using Toggle.Net.Internal;
using Toggle.Net.Providers;
using Toggle.Net.Specifications;

namespace Toggle.Net.Configuration
{
	public class ToggleConfiguration
	{
		private readonly IFeatureProviderFactory _featureProviderFactory;
		private IUserProvider _userProvider;
		private IToggleSpecification _defaultToggleSpecification;

		public ToggleConfiguration(IFeatureProviderFactory featureProviderFactory)
		{
			_featureProviderFactory = featureProviderFactory;
		}

		public ToggleConfiguration SetUserProvider(IUserProvider userProvider)
		{
			_userProvider = userProvider;
			return this;
		}

		public ToggleConfiguration SetDefaultSpecification(IToggleSpecification toggleSpecification)
		{
			_defaultToggleSpecification = toggleSpecification;
			return this;
		}


		public IToggleChecker Create()
		{
			if (_userProvider == null)
				_userProvider = new NullUserProvider();
			if(_defaultToggleSpecification==null)
				_defaultToggleSpecification = new FalseSpecification();

			var featureProvider = _featureProviderFactory.Create();
			return new ToggleChecker(featureProvider, _defaultToggleSpecification, _userProvider);
		}
	}
}