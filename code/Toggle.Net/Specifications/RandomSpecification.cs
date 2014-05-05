using System;
using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class RandomSpecification : IToggleSpecification
	{
		public const string Percent = "percent";

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			var percent = Convert.ToInt32(parameters[Percent]);
			var userHash = currentUser.GetHashCode();
			var userHash1To100 = Math.Abs(userHash%100);

			return percent > userHash1To100;
		}

		public void Validate(string toggleName, IDictionary<string, string> parameters)
		{
		}
	}
}