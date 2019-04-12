using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class LastFrame : IFrame
	{
		private readonly List<int> hits = new List<int>();

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
			var firstHitIsStrike = hits.FirstOrDefault() == 10;
			return firstHitIsStrike
				? 3
				: 2;
		}

		public bool IsStrike()
		{
			return false;
		}

		public bool IsSpare()
		{
			return false;
		}

		public int GetHitByIndexOrNull(int i)
		{
			return hits[i];
		}

		public IEnumerable<int> Hits()
		{
			return hits;
		}
	}
}