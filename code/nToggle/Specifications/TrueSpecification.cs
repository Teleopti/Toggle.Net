namespace nToggle.Specifications
{
	public class TrueSpecification : IToggleSpecification
	{
		public bool IsEnabled()
		{
			return true;
		}
	}
}