using System;

namespace nToggle.Providers.TextFile
{
	public class IncorrectTextFileException : Exception
	{
		public IncorrectTextFileException(string message) :base(message)
		{
		}
	}
}