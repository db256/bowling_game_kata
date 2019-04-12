using System.Linq;
using BowlingGameKata01.Impl;
using FluentAssertions;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	public class TestCase
	{
		private int expectedScore;
		public int[] Attempts { get; set; }

		public int ExpectedScore
		{
			get => expectedScore > 0
				? expectedScore
				: SimpleSum + ExpectedBonusScore;
			set => expectedScore = value;
		}

		public int FramesCount { get; set; } = 10;
		public int ExpectedBonusScore { get; set; }

		public int SimpleSum => Attempts.Sum();

		public override string ToString()
		{
			return ExpectedScore > 0
				? string.Join(",", Attempts) + " = " + ExpectedScore
				: string.Join(",", Attempts) + " = " + SimpleSum + " + " + ExpectedBonusScore;
		}

		public void ScoreShouldBeCorrectAfterPlay()
		{
			var game = new Game(new GameOptions
			{
				FramesCount = FramesCount
			});

			foreach (var attempt in Attempts)
			{
				game.Roll(attempt);
			}

			game.Score().Should().Be(ExpectedScore);
		}
	}
}