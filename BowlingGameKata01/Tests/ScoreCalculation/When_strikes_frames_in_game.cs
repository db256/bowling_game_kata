using System.Collections.Generic;
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
			var game = new Game(testCase.FramesCount);

			foreach (var attempt in testCase.Attempts)
			{
				game.Roll(attempt);
			}

			game.Score().Should().Be(testCase.SimpleSum + testCase.ExpectedBonusScore);
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
		}
	}
}