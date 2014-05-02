namespace Toggle.Net.Specifications
{
	public class UserSpecification : IToggleSpecification
	{
		private readonly string _activedUser;

		public UserSpecification(string activedUser)
		{
			_activedUser = activedUser;
		}

		public string Name
		{
			get { return "user"; }
		}

		public bool IsEnabled(string currentUser)
		{
			return currentUser.Equals(_activedUser);
		}
	}
}