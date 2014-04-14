namespace nToggle.Configuration.Specifications
{
	public class TrueSpecification : IToggleSpecification
	{
		public bool IsEnabled()
		{
			return true;
		}
	}
}