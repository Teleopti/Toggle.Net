using System.Collections.Generic;
using System.Linq;

namespace nToggle
{
	public class ToggleChecker : IToggleChecker
	{
		private readonly IEnumerable<string> _metadata;

		public ToggleChecker(IEnumerable<string> metadata)
		{
			_metadata = metadata;
		}

		public bool IsEnabled(string confligFlag)
		{
			return _metadata.Contains(confligFlag);
		}
	}
}