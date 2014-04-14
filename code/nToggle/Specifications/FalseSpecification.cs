namespace nToggle.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public bool IsEnabled()
		{
			return false;
		}
	}
}