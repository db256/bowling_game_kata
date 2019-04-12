using System.Collections.Generic;
using BowlingGameKata01.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	[TestFixture]
	public class Simple_frames_sequence
	{
		[TestCaseSource(nameof(TestCases))]
		public void Score_is_sum_of_attempts(TestCase testCase)
		{
			var game = new Game(testCase.FramesCount);

			foreach (var attempt in testCase.Attempts)
			{
				game.Roll(attempt);
			}

			game.Score().Should().Be(testCase.ExpectedScore);
		}

		private static IEnumerable<TestCase> TestCases()
		{
			yield return new TestCase
			{
				Attempts = new[] { 1, 7 },
				ExpectedScore = 8
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					1, 2,
					0, 9,
					2, 2
				},
				ExpectedScore = 16
			};
		}
	}
}