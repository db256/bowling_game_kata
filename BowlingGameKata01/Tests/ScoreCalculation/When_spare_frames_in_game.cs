using System.Collections.Generic;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	[TestFixture]
	public class When_spare_frames_in_game
	{
		[TestCaseSource(nameof(TestCases))]
		public void Spare_frame_add_bonus_equal_next_1_hit(TestCase testCase)
		{
			testCase.ScoreShouldBeCorrectAfterPlay();
		}

		private static IEnumerable<TestCase> TestCases()
		{
			yield return new TestCase
			{
				Attempts = new[]
				{
					1, 9,
					0, 3,
					1, 3
				},
				ExpectedBonusScore = 0
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					0, 10,
					1, 2,
					1, 2,
				},
				ExpectedBonusScore = 1
			};

			yield return new TestCase
			{
				Attempts = new[]
				{
					1, 9,
					4, 6,
					5, 3
				},
				ExpectedBonusScore = 4 + 5
			};
		}
	}
}