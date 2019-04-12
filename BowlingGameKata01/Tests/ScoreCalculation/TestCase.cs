namespace BowlingGameKata01.Tests.ScoreCalculation
{
	public class TestCase
	{
		public int[] Attempts { get; set; }
		public int ExpectedScore { get; set; }
		public int FramesCount { get; set; }

		public override string ToString()
		{
			return string.Join(",", Attempts) + " = " + ExpectedScore;
		}
	}
}