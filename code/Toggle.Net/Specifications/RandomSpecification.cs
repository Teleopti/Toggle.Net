using System;
using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class RandomSpecification : IToggleSpecification
	{
		public const string Percent = "percent";
		public const string MustHaveDeclaredPercent = "Missing RandomSpecification parameter '" + Percent + "' for feature '{0}'.";
		public const string MustDeclaredPercentAsInt = "RandomSpecification parameter '" + Percent + "' for feature '{0}' must be declared as an int.";

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			var percent = Convert.ToInt32(parameters[Percent]);
			var userHash = currentUser.GetHashCode();
			var userHash1To100 = Math.Abs(userHash%100);

			return percent > userHash1To100;
		}

		public void Validate(string toggleName, IDictionary<string, string> parameters)
		{
			string parameterValue;
			if (!parameters.TryGetValue(Percent, out parameterValue))
			{
				throw new InvalidOperationException(string.Format(MustHaveDeclaredPercent, toggleName));
			}
			int temp;
			if (!int.TryParse(parameterValue, out temp))
			{
				throw new InvalidOperationException(string.Format(MustDeclaredPercentAsInt, toggleName));
			}
		}
	}
}