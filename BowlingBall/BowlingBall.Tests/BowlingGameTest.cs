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


        [TestCase(new[] { 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 60)]
        [TestCase(new[] { 10, 10 , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 30)]
        [TestCase(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 ,10 }, 300)]
        public void Strike_Scores(int[] pins, int expectScore)
        {
            BowlingGame game = new BowlingGame();

            foreach (var pin in pins)
            {
                game.Roll(pin);
            }

            Assert.AreEqual(expectScore, game.Score);
        }

        [TestCase(new[] {8, 1, 8, 1, 4, 5, 2, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 34)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20)]
        public void Normal_Scores(int[] pins, int expectScore)
        {
            BowlingGame game = new BowlingGame();

            foreach (var pin in pins)
            {
                game.Roll(pin);
            }

            Assert.AreEqual(expectScore, game.Score);
        }


        [TestCase(new[] { 5, 5, 5, 5, 4, 5, 2, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 45)]
        [TestCase(new[] { 5, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 16)]
        [TestCase(new[] { 5, 5, 8, 2, 6, 4, 7, 3, 7, 3, 9, 1, 5, 5, 8, 2, 9, 1, 9, 1,10 }, 178)]
        public void Spare_Scores(int[] pins, int expectScore)
        {
            BowlingGame game = new BowlingGame();

            foreach (var pin in pins)
            {
                game.Roll(pin);
            }

            Assert.AreEqual(expectScore, game.Score);
        }
    }
}
