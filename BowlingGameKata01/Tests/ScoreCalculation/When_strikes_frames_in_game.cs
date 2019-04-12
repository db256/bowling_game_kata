using System;
using System.Collections.Generic;
using System.Linq;
using BowlingGameKata01.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	[TestFixture]
	public class When_strikes_frames_in_game
	{
		[TestCaseSource(nameof(TestCases))]
		public void Strike_frame_add_bonus_equal_sum_next_2_hits(TestCase testCase)
		{
			testCase.ScoreShouldBeCorrectAfterPlay();
		}

		[Test]
		public void When_all_strikes_score_should_be_correct()
		{
			var game = new Game(new GameOptions());
			var bonusHits = 2;

			foreach (var attempt in Enumerable.Repeat(10, 10 + bonusHits))
			{
				game.Roll(attempt);
			}

			game.Score().Should().Be(300);
		}

		[Test]
		public void When_all_strikes_throw_when_roll_after_game_over()
		{
			var game = new Game(new GameOptions());
			var bonusHits = 2;
			foreach (var attempt in Enumerable.Repeat(10, 10 + bonusHits))
			{
				game.Roll(attempt);
			}

			Action act = () => game.Roll(10);

			act.Should().ThrowExactly<GameOverException>();
		}

		private static IEnumerable<TestCase> TestCases()
		{
			yield return new TestCase
			{
				Attempts = new[]
				{
					10,
					3, 4,
					1, 3
				},
				ExpectedBonusScore = 3 + 4
			};
			yield return new TestCase
			{
				Attempts = new[]
				{
					10,
					10,
					1, 1
				},
				ExpectedBonusScore =
					10 + 1
					+ 1 + 1
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					10,
					10,
					7, 3
				},
				ExpectedBonusScore = 10 + 7 + 7 + 3
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					10,
					10,
					7, 3,
					4, 5
				},
				ExpectedBonusScore =
					10 + 7
					+ 7 + 3
					+ 4
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					10,
					10,
					7, 3,
					4, 5
				},
				ExpectedBonusScore =
					10 + 7
					+ 7 + 3
					+ 4
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					1, 9, 3, 3,
					2, 0, 10, 10,
					3, 7, 5, 4,
					10, 10, 10, 9, 1
				},
				ExpectedScore = 167
			};
		}
	}
}