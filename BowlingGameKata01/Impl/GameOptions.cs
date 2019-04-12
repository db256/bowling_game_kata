namespace BowlingGameKata01.Impl
{
	public class GameOptions
	{
		public int FramesCount { get; set; } = 10;
		public int TotalHitsPerFrame { get; } = 10;
		public int MaxAttemptsInFrame { get; } = 2;
		public int MaxAttemptsInLastBonusStrikeFrame { get; } = 3;
	}
}