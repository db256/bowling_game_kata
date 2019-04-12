using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class Frame
	{
		private readonly List<int> hits = new List<int>();
		private static readonly int MaxHitsCount = 2;
		private static readonly int MaxHitsSum = 10;

		public void PushHit(int hitCount)
		{
			if (hits.Count + 1 > MaxHitsCount)
				throw new Exception($"Can't push hits to current frame! Max hits in frame is {MaxHitsCount}");
			hits.Add(hitCount);
		}

		public bool IsFinished()
		{
			return IsStrike() ||
				hits.Count == MaxHitsCount;
		}

		public bool IsSpare()
		{
			return !IsStrike()
				&& hits.Sum() == MaxHitsSum;
		}

		public bool IsStrike()
		{
			return hits.Count == 1
				&& hits.First() == MaxHitsSum;
		}

		public int GetHitByIndexOrNull(int i)
		{
			return hits.ToArray()[i];
		}

		public int[] Hits()
		{
			return hits.ToArray();
		}
	}
}