using System;
using System.Collections.Generic;
using System.Linq;
using nToggle.Internal;
using nToggle.Specifications;

namespace nToggle.Providers.TextFile
{
	public class FileProvider : IFeatureProvider
	{
		private readonly string _path;
		private IDictionary<string, Feature> _features;
		private readonly IDictionary<string, IToggleSpecification> _specifications;

		public FileProvider(string path)
		{
			_path = path;
			var defaultSpecifications = new IToggleSpecification[]
			{
				new TrueSpecification(), new FalseSpecification()
			};
			_specifications = defaultSpecifications.ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
		}

		public Feature Get(string flagName)
		{
			if (_features == null)
				_features = parseFile();

			return _features[flagName];
		}

		private IDictionary<string, Feature> parseFile()
		{
			var readFeatures = new Dictionary<string, Feature>(StringComparer.OrdinalIgnoreCase);
			foreach (var row in ReadContent().Content(_path))
			{
				var splitByEqualSign = row.Split('=');
				var flag = splitByEqualSign[0].Trim();
				var specificationName = splitByEqualSign[1].Trim();
				IToggleSpecification foundSpecification;
				if (_specifications.TryGetValue(specificationName, out foundSpecification))
				{
					readFeatures.Add(flag, new Feature(flag, foundSpecification));
				}
			}
			return readFeatures;
		}

		protected virtual IContentReader ReadContent()
		{
			return new ContentReader();
		}
	}
}