using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BowlingBall.Tests
{
    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void All_PinEmpty_Score0()
        {

            BowlingGame game = new BowlingGame();

            int expectScore = 0;

            foreach (var s in Enumerable.Repeat(0, 21))
            {
                game.Roll(s);
            }

            Assert.AreEqual(expectScore, game.Score);
        }

        [TestCase(new [] { 8, 2, 8, 1, 5, 5 },29)]
        [TestCase(new [] { 10, 10, 10 }, 60)]
        [TestCase(new [] { 10, 10 }, 30)]
        [TestCase(new[]  { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300)]
        public void PinNormal_Scores_is_29(int[] pins,int expectScore)
        {
            BowlingGame game = new BowlingGame();

            foreach (var pin in pins)
            {
                game.Roll(pin);
            }

            Assert.AreEqual(expectScore,game.Score);
        }

    }
}
