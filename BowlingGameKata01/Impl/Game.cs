using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class Game
	{
		private readonly LinkedList<IFrame> frames = new LinkedList<IFrame>();
		private readonly int framesCountInGame;

		public Game(int framesCountInGame)
		{
			this.framesCountInGame = framesCountInGame;
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
			if (IsOver())
				throw new GameException("Can't hit rolls, game is over!");
			var frame = CreateNewFrame();
			frames.AddLast(new LinkedListNode<IFrame>(frame));
		}

		private IFrame CreateNewFrame()
		{
			if (frames.Count + 1 >= framesCountInGame)
				return new LastFrame();
			return new NotLastFrame();
		}

		private IFrame CurrentFrame()
		{
			return frames.Last.Value;
		}

		public int Score()
		{
			var simpleSum = SimpleSum();
			var spareBonus = SpareBonus();
			var strikeBonus = BonusForStrikes();
			return simpleSum + spareBonus + strikeBonus;
		}

		private int BonusForStrikes()
		{
			var strikeFrames = EnumerateFrames()
				.Where(f => f.Value.IsStrike());

			var strikeBonuses = strikeFrames
				.Select(f => HitsFromNext2Frames(f).Take(2).Sum());

			return strikeBonuses
				.Sum();
		}

		private IEnumerable<int> HitsFromNext2Frames(LinkedListNode<IFrame> frame)
		{
			var interestingFrames = new[]
			{
				frame.Next,
				frame.Next?.Next
			};
			return interestingFrames
				.Where(f => f != null)
				.SelectMany(f => f.Value.Hits());
		}

		private int SimpleSum()
		{
			return EnumerateFrames()
				.Select(f => f.Value.Hits().Sum())
				.Sum();
		}

		private int SpareBonus()
		{
			return EnumerateFrames()
				.Where(f => f.Value.IsSpare())
				.Select(f => f.Next?.Value.GetHitByIndexOrNull(0))
				.Where(nextHit => nextHit != null)
				.Sum() ?? 0;
		}

		public bool IsOver()
		{
			return frames.Count == framesCountInGame
				&& CurrentFrame().IsFinished();
		}

		private IEnumerable<LinkedListNode<IFrame>> EnumerateFrames()
		{
			var current = frames.First;
			yield return current;
			while (current.Next != null)
			{
				yield return current.Next;
				current = current.Next;
			}
		}
	}
}