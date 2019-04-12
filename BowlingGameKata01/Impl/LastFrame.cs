using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class LastFrame : IFrame
	{
		private readonly List<int> hits = new List<int>();
		private readonly GameOptions gameOptions;

		public LastFrame(GameOptions gameOptions)
		{
			this.gameOptions = gameOptions;
		}

		public void PushHit(int hitCount)
		{
			hits.Add(hitCount);
		}

		public bool IsFinished()
		{
			return hits.Count == AllowedHitsCount();
		}

		private int AllowedHitsCount()
		{
			var firstHitIsStrike = hits.FirstOrDefault() == gameOptions.TotalHitsPerFrame;
			return firstHitIsStrike
				? gameOptions.MaxAttemptsInLastBonusStrikeFrame
				: gameOptions.MaxAttemptsInFrame;
		}

		public bool IsStrike()
		{
			return false;
		}

		public bool IsSpare()
		{
			return false;
		}

		public IEnumerable<int> Hits()
		{
			return hits;
		}
	}
}