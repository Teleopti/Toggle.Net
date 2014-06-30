using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Toggle.Net.Specifications
{
	public class RegExSpecification : IToggleSpecification
	{
		public const string MustDeclareRegexPattern = "Missing parameter '" + RegExParameter + "' for Feature '{0}'.";
		public const string RegExParameter = "pattern";

		private readonly Regex _regex;

		public RegExSpecification(Regex regex)
		{
			_regex = regex;
		}

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			return _regex.IsMatch(parameters[RegExParameter]);
		}

		public void Validate(string toggleName, IDictionary<string, string> parameters)
		{
			if (!parameters.ContainsKey(RegExParameter))
				throw new InvalidSpecificationParameterException(string.Format(MustDeclareRegexPattern, toggleName));
		}
	}
}