using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toggle.Net.Internal;
using Toggle.Net.Specifications;

namespace Toggle.Net.Providers.TextFile
{
	/// <summary>
	/// Reads flags and their <see cref="IToggleSpecification"/> from a text file.
	/// 
	/// Format
	/// [flag]=[specification]
	/// [flag].[specification].[param]=[value]
	/// 
	/// To remark, use "#" sign.
	/// 
	/// <example>
	/// # This is an example
	/// 
	/// NewFeature = false
	/// Logon = true
	/// TheThing = myspecification
	/// TheThing.myspecification.MyParam = 13
	/// TheThing.myspecification.MyOtherParam = 13
	/// </example>
	/// </summary>
	public class FileProvider : IFeatureProvider
	{
		public const string MustContainEqualSign = "Missing equal sign at line {0}.";
		public const string MustOnlyContainOneEqualSign = "More than one equal sign at line {0}.";
		public const string MustHaveValidSpecification = "Unknown specification '{0}' at line {1}.";
		public const string MustHaveTwoDotsIfParameterUse =
			"Wrong parameter usage at line {0}. Use format [feature].[specification].[parametername] = [parametervalue].";

		private readonly IFileReader _fileReader;
		private IDictionary<string, Feature> _features;
		private readonly IDictionary<string, IToggleSpecification> _specifications;

		public FileProvider(IFileReader fileReader)
		{
			_fileReader = fileReader;
			var defaultSpecifications = new IToggleSpecification[]
			{
				new TrueSpecification(), new FalseSpecification()
			};
			_specifications = defaultSpecifications.ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
		}

		public void AddSpecification(IToggleSpecification toggleSpecification)
		{
			_specifications.Add(toggleSpecification.Name, toggleSpecification);
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
			var content = _fileReader.Content();
			var exOutput = new StringBuilder();
			for (var index = 0; index < content.Length; index++)
			{
				var row = content[index];
				var rowNumber = index + 1;
				var splitByEqualSign = row.Split('=');
				var leftOfEqualSign = splitByEqualSign[0].Trim();
				if (leftOfEqualSign == string.Empty || leftOfEqualSign.StartsWith("#"))
					continue;
				switch (splitByEqualSign.Length)
				{
					case 1:
						exOutput.AppendLine(string.Format(MustContainEqualSign, rowNumber));
						break;
					case 2:
						var rightOfEqualSign = splitByEqualSign[1].Trim();
						parseRow(readFeatures, leftOfEqualSign, rightOfEqualSign, rowNumber, exOutput);
						break;
					default:
						exOutput.AppendLine(string.Format(MustOnlyContainOneEqualSign, rowNumber));
						break;
				}
			}
			if (exOutput.Length > 0)
				throw new IncorrectTextFileException(exOutput.ToString());
			return readFeatures;
		}

		private void parseRow(IDictionary<string, Feature> readFeatures, string leftOfEqualSign, string rightOfEqualSign, int rowNumber, StringBuilder exOutput)
		{
			var splitLeftByDots = leftOfEqualSign.Split('.');
			switch (splitLeftByDots.Length)
			{
				case 1:
					IToggleSpecification foundSpecification;
					if (_specifications.TryGetValue(rightOfEqualSign, out foundSpecification))
					{
						if (readFeatures.ContainsKey(leftOfEqualSign))
						{
							readFeatures[leftOfEqualSign].AddSpecification(foundSpecification);
						}
						else
						{
							readFeatures.Add(leftOfEqualSign, new Feature(leftOfEqualSign, foundSpecification));
						}
					}
					else
					{
						exOutput.AppendLine(string.Format(MustHaveValidSpecification, rightOfEqualSign, rowNumber));
					}
					break;
				case 3:
					var flag = splitLeftByDots[0];
					var specification = splitLeftByDots[1];
					var paramName = splitLeftByDots[2];
					var paramValue = rightOfEqualSign;
					_specifications[specification].AddParameter(paramName, paramValue);
					break;
				default:
					exOutput.AppendLine(string.Format(MustHaveTwoDotsIfParameterUse, rowNumber));
					break;
			}
		}
	}
}