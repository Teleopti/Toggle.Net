using System.Collections.Generic;
using nToggle.Internal;
using nToggle.Specifications;

namespace nToggle.Providers.TextFile
{
	public class FileProvider : IFeatureProvider
	{
		private readonly string _path;
		private IDictionary<string, Feature> _features;

		public FileProvider(string path)
		{
			_path = path;
		}

		public Feature Get(string flagName)
		{
			if (_features == null)
				_features = parseFile();

			return _features[flagName];
		}

		private IDictionary<string, Feature> parseFile()
		{
			var readFeatures = new Dictionary<string, Feature>();
			foreach (var row in ReadContent().Content(_path))
			{
				var splitByEqualSign = row.Split('=');
				var flag = splitByEqualSign[0];
				var trueOrFalse = splitByEqualSign[1];
				if (trueOrFalse.Equals("true"))
				{
					readFeatures.Add(flag, new Feature(flag, new TrueSpecification()));
				}
				if (trueOrFalse.Equals("false"))
				{
					readFeatures.Add(flag, new Feature(flag, new FalseSpecification()));
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