using System;
using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class RandomSpecification : IToggleSpecification
	{
		public const string Percent = "percent";
		public const string MustHaveDeclaredPercent = "Missing RandomSpecification parameter '" + Percent + "' for feature '{0}'.";
		public const string MustDeclaredPercentAsInt = "RandomSpecification parameter '" + Percent + "' for feature '{0}' must be declared as an int.";
		public const string MustBeBetween0And100 = "RandomSpecification parameter '" + Percent + "' for feature '{0}' must be between 0 and 100.";

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
			int percent;
			if (!int.TryParse(parameterValue, out percent))
			{
				throw new InvalidOperationException(string.Format(MustDeclaredPercentAsInt, toggleName));
			}
			if (percent < 0 || percent > 100)
			{
				throw new InvalidOperationException(string.Format(MustBeBetween0And100, toggleName));
			}
		}
	}
}