namespace Toggle.Net.Specifications
{
	public class FalseSpecification : ToggleSpecification
	{
		public override string Name
		{
			get { return "false"; }
		}

		public override bool IsEnabled(string currentUser)
		{
			return false;
		}
	}
}