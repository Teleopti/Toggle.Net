namespace nToggle.Configuration.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public bool IsEnabled()
		{
			return false;
		}
	}
}