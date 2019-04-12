using System.Collections.Generic;
using BowlingGameKata01.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	[TestFixture]
	public class When_strike_at_last_frame
	{
		[TestCaseSource(nameof(TestCases))]
		public void Then_last_frame_contains_3_hits(TestCase testCase)
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
				FramesCount = 3,
				Attempts = new[]
				{
					1, 1,
					1, 1,
					10, 7, 3
				},
				ExpectedScore =
					1 + 1
					+ 1 + 1
					+ 10 + 7 + 3
			};
			yield return new TestCase
			{
				FramesCount = 3,
				Attempts = new[]
				{
					1, 1,
					1, 1,
					10, 7, 3
				},
				ExpectedBonusScore = 0
			};
		}
	}
}