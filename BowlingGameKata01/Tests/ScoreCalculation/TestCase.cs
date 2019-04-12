using System.Linq;

namespace BowlingGameKata01.Tests.ScoreCalculation
{
	public class TestCase
	{
		public int[] Attempts { get; set; }
		public int ExpectedScore { get; set; }
		public int FramesCount { get; set; } = 10;
		public int ExpectedBonusScore { get; set; }

		public int SimpleSum => Attempts.Sum();

		public override string ToString()
		{
			return ExpectedScore > 0
				? string.Join(",", Attempts) + " = " + ExpectedScore
				: string.Join(",", Attempts) + " = " + SimpleSum + " + " + ExpectedBonusScore;
		}
	}
}