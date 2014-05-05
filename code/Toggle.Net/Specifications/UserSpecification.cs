using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class UserSpecification : IToggleSpecification
	{
		private readonly string _activedUser;

		public UserSpecification(string activedUser)
		{
			_activedUser = activedUser;
		}

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			return currentUser.Equals(_activedUser);
		}
	}
}