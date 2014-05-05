using System;
using System.Collections.Generic;
using System.Linq;

namespace Toggle.Net.Specifications
{
	/// <summary>
	/// Is enabled for certain user(s).
	/// If parameter value contains comma(s),
	/// it is treated as a list.
	/// If not, a single string as currentUser is expected.
	/// </summary>
	public class UserSpecification : IToggleSpecification
	{
		public const string Ids = "ids";
		public const string MustHaveDeclaredIds = "Missing UserSpecification parameter '" + Ids + "' for feature '{0}'.";

		private const char delimiter = ',';

		public void Validate(string toggleName, IDictionary<string, string> parameters)
		{
			if (!parameters.Keys.Contains(Ids))
			{
				throw new InvalidOperationException(string.Format(MustHaveDeclaredIds, toggleName));
			}
		}

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			var currentUserContainsDelimiter = currentUser.Contains(delimiter);
			var parameterValues = parameters[Ids];

			if (currentUserContainsDelimiter)
			{
				return parameterValues.Equals(currentUser);
			}

			var values = parameterValues.Split(delimiter);
			return values.Any(value => value.Trim().Equals(currentUser));
		}
	}
}