namespace Toggle.Net.Specifications
{
	public class TrueSpecification : ToggleSpecification
	{
		public override string Name
		{
			get { return "true"; }
		}

		public override bool IsEnabled(string currentUser)
		{
			return true;
		}
	}
}