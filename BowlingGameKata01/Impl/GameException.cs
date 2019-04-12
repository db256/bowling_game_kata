using System;

namespace BowlingGameKata01.Impl
{
	public class GameException : Exception
	{
		public GameException(string message) : base(message)
		{
		}
	}
}