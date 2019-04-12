using System;
using BowlingGameKata01.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameKata01.Tests.GameOverWhen
{
	[TestFixture]
	public class Game_is_over_when_all_frames_finished
	{
		[Test]
		public void Game_is_not_finished_when_not_all_frames()
		{
			var game = new Game(2);
			game.IsOver().Should().BeFalse();
		}

		[Test]
		public void Game_is_finished_when_all_frames_hits_over()
		{
			var game = new Game(2);
			game.Roll(1);
			game.Roll(2);
			game.Roll(1);
			game.Roll(2);
			game.IsOver().Should().BeTrue();
		}

		[Test]
		public void Throw_when_try_hit_after_game_is_over()
		{
			var game = new Game(1);
			game.Roll(1);
			game.Roll(2);
			Action act = () => game.Roll(1);
			act.Should().ThrowExactly<GameException>()
				.WithMessage("Can't hit rolls, game is over!");
		}
	}
}