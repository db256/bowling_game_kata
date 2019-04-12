using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class NotLastFrame : IFrame
	{
		private readonly List<int> hits = new List<int>();
		private readonly GameOptions gameOptions;

		public NotLastFrame(GameOptions gameOptions)
		{
			this.gameOptions = gameOptions;
		}

		public void PushHit(int hitCount)
		{
			hits.Add(hitCount);
		}

		public bool IsFinished()
		{
			return IsStrike()
				|| hits.Count == gameOptions.MaxAttemptsInFrame;
		}

		public bool IsStrike()
		{
			return hits.Count == 1
				&& hits.First() == gameOptions.TotalHitsPerFrame;
		}

		public bool IsSpare()
		{
			return !IsStrike()
				&& hits.Sum() == gameOptions.TotalHitsPerFrame;
		}

		public IEnumerable<int> Hits()
		{
			return hits;
		}
	}
}