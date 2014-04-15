using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nToggle.Internal;
using nToggle.Specifications;

namespace nToggle.Providers.TextFile
{
	/// <summary>
	/// Reads flags and their <see cref="IToggleSpecification"/> from a text file.
	/// 
	/// Format
	/// [flag]=[specification]
	/// [flag].[specification].[param]=[value]
	/// </summary>
	public class FileProvider : IFeatureProvider
	{
		public const string MustContainEqualSign = "Missing equal sign at line {0}.";
		public const string MustOnlyContainOneEqualSign = "More than one equal sign at line {0}.";

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

			Feature feature;
			return _features.TryGetValue(flagName, out feature) ?
					feature :
					null;
		}

		private IDictionary<string, Feature> parseFile()
		{
			var readFeatures = new Dictionary<string, Feature>(StringComparer.OrdinalIgnoreCase);
			var content = ReadContent().Content(_path);
			var exOutput = new StringBuilder();
			for (var index = 0; index < content.Length; index++)
			{
				var row = content[index];
				var rowNumber = index + 1;
				var splitByEqualSign = row.Split('=');
				var numberOfSplits = splitByEqualSign.Length;
				switch (numberOfSplits)
				{
					case 1:
						exOutput.AppendLine(string.Format(MustContainEqualSign, rowNumber));
						break;
					case 2:
						var flag = splitByEqualSign[0].Trim();
						var specificationName = splitByEqualSign[1].Trim();
						IToggleSpecification foundSpecification;
						if (_specifications.TryGetValue(specificationName, out foundSpecification))
						{
							readFeatures.Add(flag, new Feature(flag, foundSpecification));
						}
						break;
					default:
						exOutput.AppendLine(string.Format(MustOnlyContainOneEqualSign, rowNumber));
						break;
				}
			}
			if(exOutput.Length>0)
				throw new IncorrectTextFileException(exOutput.ToString());
			return readFeatures;
		}

		protected virtual IContentReader ReadContent()
		{
			return new ContentReader();
		}
	}
}