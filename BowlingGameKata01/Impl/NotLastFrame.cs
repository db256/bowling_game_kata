using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class NotLastFrame : IFrame
	{
		private readonly List<int> hits = new List<int>();
		private static readonly int MaxHitsCount = 2;
		private static readonly int MaxHitsSum = 10;

		public void PushHit(int hitCount)
		{
			if (IsFinished())
				throw new GameException("Can't push hits to current frame! Frame is finished!");
			hits.Add(hitCount);
		}

		public bool IsFinished()
		{
			return IsStrike()
				|| hits.Count == MaxHitsCount;
		}

		public bool IsStrike()
		{
			return hits.Count == 1
				&& hits.First() == MaxHitsSum;
		}

		public bool IsSpare()
		{
			return !IsStrike()
				&& hits.Sum() == MaxHitsSum;
		}

		public int GetHitByIndexOrNull(int i)
		{
			return hits.ToArray()[i];
		}

		public IEnumerable<int> Hits()
		{
			return hits;
		}
	}
}