using System;
using System.Collections.Generic;
using System.Linq;

namespace nToggle.Internal
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IDictionary<string, Feature> _metadata;
		private const string duplicateEx = "At least one flag is defined more than once: {0}";
		private const string missingSpecificationEx = "At least one feature has no specification defined: {0}";

		public ToggleChecker(IEnumerable<Feature> metadata)
		{
			verifyNoDuplicates(metadata);
			_metadata = metadata.ToDictionary(x => x.FlagName);
		}

		public bool IsEnabled(string flagName)
		{
			Feature feature;
			return _metadata.TryGetValue(flagName, out feature) && feature.IsEnabled();
		}

		private static void verifyNoDuplicates(IEnumerable<Feature> orginalFeatures)
		{
			var tempHash = new HashSet<string>();
			var uniqueFlags = new HashSet<string>();
			var noSpecifications = new HashSet<string>();
			foreach (var originalFeature in orginalFeatures)
			{
				if (!tempHash.Add(originalFeature.FlagName))
				{
					uniqueFlags.Add(originalFeature.FlagName);
				}
				if (!originalFeature.Specifications.Any())
				{
					noSpecifications.Add(originalFeature.FlagName);
				}
			}
			if (uniqueFlags.Any())
			{
				throw new InvalidOperationException(string.Format(duplicateEx, string.Join(", ", uniqueFlags)));
			}
			if (noSpecifications.Any())
			{
				throw new InvalidOperationException(string.Format(missingSpecificationEx, string.Join(", ", noSpecifications)));
			}
		}
	}
}