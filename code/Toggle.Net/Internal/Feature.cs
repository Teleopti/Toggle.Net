using System;
using System.Collections.Generic;
using System.Linq;
using Toggle.Net.Specifications;

namespace Toggle.Net.Internal
{
	public class Feature
	{
		public const string FlagNameMustNotContainDots = "Flag name must not contain dots.";

		private readonly IDictionary<IToggleSpecification, IDictionary<string, string>> _specificationData;

		public Feature(string flagName, IToggleSpecification specification)
		{
			if (flagName.Contains("."))
			{
				throw new ArgumentException(FlagNameMustNotContainDots);
			}

			FlagName = flagName;
			_specificationData = new Dictionary<IToggleSpecification, IDictionary<string, string>>();
			AddSpecification(specification);
		}

		public string FlagName { get; private set; }

		public bool IsEnabled(string currentUser)
		{
			return _specificationData.Keys.All(specification =>
				specification.IsEnabled(currentUser, _specificationData[specification]));
		}

		public void AddSpecification(IToggleSpecification specification)
		{
			if(specification==null)
				throw new ArgumentNullException("specification");
			_specificationData.Add(specification, new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
		}

		public void AddParameter(IToggleSpecification specification, string parameterName, string parameterValue)
		{
			_specificationData[specification].Add(parameterName, parameterValue);
		}
	}
}