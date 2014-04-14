using nToggle.Repositories;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IFeatureRepository _featureRepository;

		public ToggleChecker(IFeatureRepository featureRepository)
		{
			_featureRepository = featureRepository;
		}

		public bool IsEnabled(string flagName)
		{
			var feature = _featureRepository.Get(flagName);
			return feature != null && feature.IsEnabled();
		}
	}
}