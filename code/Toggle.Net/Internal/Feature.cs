using System;
using System.Collections.Generic;
using System.Linq;
using Toggle.Net.Specifications;

namespace Toggle.Net.Internal
{
	public class Feature
	{
		public const string FlagNameMustNotContainDots = "Flag name must not contain dots.";

		private readonly ICollection<IToggleSpecification> _specifications;
		private readonly IDictionary<IToggleSpecification, IDictionary<string, string>> _parameters;

		public Feature(string flagName, IToggleSpecification specification)
		{
			if (flagName.Contains("."))
			{
				throw new ArgumentException(FlagNameMustNotContainDots);
			}

			FlagName = flagName;
			_specifications = new List<IToggleSpecification>();
			_parameters = new Dictionary<IToggleSpecification, IDictionary<string, string>>();
			AddSpecification(specification);
		}

		public string FlagName { get; private set; }

		public bool IsEnabled(string currentUser)
		{
			return _specifications.All(specification =>
			{
				IDictionary<string, string> parameters;
				if (!_parameters.TryGetValue(specification, out parameters))
				{
					parameters = new Dictionary<string, string>();
				}
				return specification.IsEnabled(currentUser, parameters);
			});
		}

		public void AddSpecification(IToggleSpecification specification)
		{
			if(specification==null)
				throw new ArgumentNullException("specification");
			_specifications.Add(specification);
		}

		public void AddParameter(IToggleSpecification specification, string parameterName, string parameterValue)
		{
			IDictionary<string, string> parameterState;
			if (!_parameters.TryGetValue(specification, out parameterState))
			{
				parameterState=new Dictionary<string, string>();
			}
			parameterState[parameterName] = parameterValue;
			_parameters[specification] = parameterState;
		}
	}
}