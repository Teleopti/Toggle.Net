namespace Toggle.Net.Specifications
{
	public class UserSpecification : ToggleSpecification
	{
		private readonly string _activedUser;

		public UserSpecification(string activedUser)
		{
			_activedUser = activedUser;
		}

		public override string Name
		{
			get { return "user"; }
		}

		public override bool IsEnabled(string currentUser)
		{
			return currentUser.Equals(_activedUser);
		}
	}
}