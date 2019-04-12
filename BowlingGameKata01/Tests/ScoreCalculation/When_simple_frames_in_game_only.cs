using System.Collections.Generic;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	[TestFixture]
	public class When_simple_frames_in_game_only
	{
		[TestCaseSource(nameof(TestCases))]
		public void Score_is_sum_of_attempts(TestCase testCase)
		{
			testCase.ScoreShouldBeCorrectAfterPlay();
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