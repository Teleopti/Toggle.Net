namespace Toggle.Net.Specifications
{
	public class TrueSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "true"; }
		}

		public bool IsEnabled(string currentUser)
		{
			return true;
		}
	}
}