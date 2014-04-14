using System;
using System.Collections.Generic;
using System.Linq;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IDictionary<string, Feature> _metadata;
		private const string duplicateEx = "At least one flag is defined more than once: {0}";

		public ToggleChecker(IEnumerable<Feature> metadata)
		{
			verifyNoDuplicates(metadata);
			_metadata = metadata.ToDictionary(x => x.FlagName);
		}

		private static void verifyNoDuplicates(IEnumerable<Feature> orginalFeatures)
		{
			var tempHash = new HashSet<string>();
			var illegalFlags = new HashSet<string>();
			foreach (var originalFeature in orginalFeatures.Where(originalFeature => !tempHash.Add(originalFeature.FlagName)))
			{
				illegalFlags.Add(originalFeature.FlagName);
			}
			if (illegalFlags.Any())
			{
				throw new InvalidOperationException(string.Format(duplicateEx, string.Join(", ", illegalFlags)));
			}
		}

		public bool IsEnabled(string flagName)
		{
			Feature feature;
			return _metadata.TryGetValue(flagName, out feature) && feature.IsEnabled();
		}
	}
}