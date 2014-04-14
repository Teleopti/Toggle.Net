using System.Collections.Generic;
using System.IO;
using nToggle.Internal;
using nToggle.Specifications;

namespace nToggle.Providers.TextFile
{
	public class FileProvider : IFeatureProvider
	{
		private readonly string _path;
		private IDictionary<string, Feature> _features;
		private IReadContent _readContent;

		public FileProvider(string path)
		{
			_path = path;
			_readContent = new ReadContent();
		}

		public Feature Get(string flagName)
		{
			if (_features == null)
			{
				_features = new Dictionary<string, Feature>();
				foreach (var row in _readContent.Content(_path))
				{
					var splitByEqualSign = row.Split('=');
					var flag = splitByEqualSign[0];
					var trueOrFalse = splitByEqualSign[1];
					if (trueOrFalse.Equals("true"))
					{
						_features.Add(flag, new Feature(flag, new TrueSpecification()));
					}
				}	
			}
			return _features[flagName];
		}
	}
}