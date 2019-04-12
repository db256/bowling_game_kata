using System.Collections.Generic;

namespace BowlingGameKata01.Impl
{
	public interface IFrame
	{
		void PushHit(int hitCount);
		bool IsFinished();
		bool IsStrike();
		bool IsSpare();
		IEnumerable<int> Hits();
	}
}