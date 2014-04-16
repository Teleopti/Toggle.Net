namespace nToggle.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "false"; }
		}

		public bool IsEnabled()
		{
			return false;
		}
	}
}