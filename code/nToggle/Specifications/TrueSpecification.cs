namespace nToggle.Specifications
{
	public class TrueSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "true"; }
		}

		public bool IsEnabled()
		{
			return true;
		}
	}
}