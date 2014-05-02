namespace Toggle.Net.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "false"; }
		}

		public bool IsEnabled(string currentUser)
		{
			return false;
		}
	}
}