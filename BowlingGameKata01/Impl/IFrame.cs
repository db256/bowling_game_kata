using System.Collections.Generic;

namespace BowlingGameKata01.Impl
{
	public interface IFrame
	{
		void PushHit(int hitCount);
		bool IsFinished();
		bool IsStrike();
		bool IsSpare();
		int GetHitByIndexOrNull(int i);
		IEnumerable<int> Hits();
	}
}