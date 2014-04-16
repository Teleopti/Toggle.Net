using NetToggle.Providers;

namespace NetToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureProvider _featureProvider;

		public ToggleChecker(IFeatureProvider featureProvider)
		{
			_featureProvider = featureProvider;
		}

		public bool IsEnabled(string flagName)
		{
			var feature = _featureProvider.Get(flagName);
			return feature != null && feature.IsEnabled();
		}
	}
}