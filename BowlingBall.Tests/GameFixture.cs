using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        public GameFixture()
        {
            g = new Game();
        }

        private void rollPins(int numberOfRolls, int pinsHitPerRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                g.Roll(pinsHitPerRoll);
            }
        }

        private void defaultRollSpare()
        {
            g.Roll(6);
            g.Roll(4);
        }


        [Fact]
        public void TestAllZero()
        {
            rollPins(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            rollPins(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            defaultRollSpare();
            g.Roll(4);
            rollPins(17, 0);
            Assert.Equal(18, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);
            rollPins(17, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestAllStrike()
        {
            rollPins(13, 10);
            Assert.Equal(300, g.GetScore());
        }


        [Fact]
        public void TestAllSpare()
        {
            Game game = new Game();
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }

            Assert.Equal(150, game.GetScore());
        }


        [Fact]
        public void TestPerfectGame()
        {
            rollPins(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestAllStrikes()
        {
            rollPins(20, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestNoExtraRoll()
        {
            int[] input = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 };
            for (int i = 0; i < input.Length; i++)
            {
                g.Roll(input[i]);
            }
            Assert.Equal(131, g.GetScore());
        }

        [Fact]
        public void TestGameWithSpareThenStrikeAtEnd()
        {
            int[] input = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 };
            for (int i = 0; i < input.Length; i++)
            {
                g.Roll(input[i]);
            }
            Assert.Equal(143, g.GetScore());
        }

        [Fact]
        public void TestGameWithThreeStrikesAtEnd()
        {
            int[] input = new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 };
            for (int i = 0; i < input.Length; i++)
            {
                g.Roll(input[i]);
            }

            Assert.Equal(163, g.GetScore());
        }
    }
}
