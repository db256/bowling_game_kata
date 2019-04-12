using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class Game
	{
		private readonly LinkedList<Frame> frames = new LinkedList<Frame>();
		private readonly int framesCount;

		public Game(int framesCount)
		{
			this.framesCount = framesCount;
			OpenNewFrame();
		}

		public void Roll(int hitCount)
		{
			if (CurrentFrame().IsFinished())
				OpenNewFrame();

			CurrentFrame().PushHit(hitCount);
		}

		private void OpenNewFrame()
		{
			if (IsFinished())
				throw new GameException("Can't hit rolls, game is over!");
			frames.AddLast(new LinkedListNode<Frame>(new Frame()));
		}

		private Frame CurrentFrame()
		{
			return frames.Last.Value;
		}

		public int Score()
		{
			var simpleSum = EnumerateFrames()
				.Select(f => f.Value.HitsSum())
				.Sum();

			var bonus = EnumerateFrames()
				.Where(f => f.Value.IsSpare())
				.Select(f => f.Next?.Value.GetHitByIndexOrNull(0))
				.Where(nextHit => nextHit != null)
				.Sum() ?? 0;

			return simpleSum + bonus;
		}

		private IEnumerable<LinkedListNode<Frame>> EnumerateFrames()
		{
			var current = frames.First;
			yield return current;
			while (current.Next != null)
			{
				yield return current.Next;
				current = current.Next;
			}
		}

		public bool IsFinished()
		{
			return frames.Count == framesCount
				&& CurrentFrame().IsFinished();
		}
	}
}