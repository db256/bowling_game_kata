using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class Frame
	{
		private readonly List<int> hits = new List<int>();
		private static readonly int MaxHitsInFrame = 2;

		public void PushHit(int hitCount)
		{
			if (hits.Count + 1 > MaxHitsInFrame)
				throw new Exception($"Can't push hits to current frame! Max hits in frame is {MaxHitsInFrame}");
			hits.Add(hitCount);
		}

		public bool IsFinished()
		{
			return hits.Count == MaxHitsInFrame;
		}

		public int HitsSum()
		{
			return hits.Sum();
		}

		public bool IsSpare()
		{
			return hits.Sum() == 10;
		}

		public int GetHitByIndexOrNull(int i)
		{
			return hits.ToArray()[i];
		}
	}
}