using System.Collections.Generic;
using System.Linq;

namespace Toggle.Net.Specifications
{
	public class UserSpecification : IToggleSpecification
	{
		public const string Ids = "ids";

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			var parameterValues = parameters[Ids];
			var values = parameterValues.Split(',');
			return values.Any(value => value.Trim().Equals(currentUser));
		}
	}
}