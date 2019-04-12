using System.Collections.Generic;
using System.Linq;
using BowlingGameKata01.Framework.Extensions;

namespace BowlingGameKata01.Impl
{
	public class Game
	{
		private readonly LinkedList<IFrame> frames = new LinkedList<IFrame>();
		private readonly GameOptions gameOptions;

		public Game(GameOptions gameOptions)
		{
			this.gameOptions = gameOptions;
			OpenNewFrame();
		}

		public void Roll(int hitCount)
		{
			if (IsOver())
				throw new GameOverException();

			if (CurrentFrame().IsFinished())
				OpenNewFrame();

			CurrentFrame().PushHit(hitCount);
		}

		private void OpenNewFrame()
		{
			var frame = ProvideNewFrame();
			frames.AddLast(new LinkedListNode<IFrame>(frame));
		}

		private IFrame ProvideNewFrame()
		{
			if (frames.Count + 1 >= gameOptions.FramesCount)
				return new LastFrame(gameOptions);
			return new NotLastFrame(gameOptions);
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

		private IEnumerable<LinkedListNode<IFrame>> EnumerateFrames()
		{
			return frames.ToNodes();
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
				.Select(f => f.Next?.Value.Hits().First())
				.Where(nextHit => nextHit != null)
				.Sum() ?? 0;
		}

		public bool IsOver()
		{
			return frames.Count == gameOptions.FramesCount
				&& CurrentFrame().IsFinished();
		}
	}
}