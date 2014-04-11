namespace nToggle
{
	public class ToggleCheckerFactory
	{
		private readonly InMemoryConfiguration _configuration;

		public ToggleCheckerFactory(InMemoryConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IToggleChecker Build()
		{
			return new ToggleChecker(_configuration.Metadata());
		}
	}
}