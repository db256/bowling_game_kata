using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata01.Impl
{
	public class Game
	{
		private readonly List<Frame> frames = new List<Frame>
		{
			new Frame()
		};
		private readonly int framesCount;

		public Game(int framesCount)
		{
			this.framesCount = framesCount;
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
			frames.Add(new Frame());
		}

		private Frame CurrentFrame()
		{
			return frames.Last();
		}

		public int Score()
		{
			return frames
				.Select(frame => frame.HitsSum())
				.Sum();
		}

		public bool IsFinished()
		{
			return frames.Count == framesCount
				&& frames.Last().IsFinished();
		}
	}
}