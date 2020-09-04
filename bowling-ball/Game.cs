using System;

namespace BowlingBall
{
    public class Game
    {
        #region Private Properties
        private int[] rolls = new int[21];
        private int[] frame = new int[10];
        private int currentRoll = 0;
        private const int defaultScore = 10;
        #endregion


        #region Validate and Calculate bonus methods

        /// <summary>
        /// Checks if it is Spare 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns>true if is spare else false</returns>
        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == defaultScore;
        }

        /// <summary>
        /// Checks if it is strike ie 10
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns>true if is strike else false</returns>
        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == defaultScore;
        }

        /// <summary>
        /// Calcualte bonus for strike and spare
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="score"></param>

        private void CalculateBouns(ref int frameIndex, ref int score)
        {
            try
            {
                if (isSpare(frameIndex))
                {
                    score += defaultScore + rolls[frameIndex + 2];
                    frameIndex += 2;
                }

                else if (isStrike(frameIndex))
                {
                    score += defaultScore + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }

                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Public methods
        /// <summary>
        /// Update rolls array by adding pins
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        /// <summary>
        /// Update rolls array by adding pins and iterate till the numberOfRolls
        /// </summary>
        /// <param name="numberOfRolls"></param>
        /// <param name="pinsHitPerRoll"></param>
        public void rollPins(int numberOfRolls, int pinsHitPerRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                Roll(pinsHitPerRoll);
            }
        }

        /// <summary>
        /// Calculate bowling score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                CalculateBouns(ref frameIndex, ref score);
            }
            return score;
        }

        #endregion



    }
}

