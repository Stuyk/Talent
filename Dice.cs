﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public static class Dice
    {
        public readonly static Random Random = new Random();

        /// <summary>
        /// Returns a random number between 1 and the sides issued.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        public static int RollDice(int sides = 20)
        {
            return Random.Next(1, sides + 1);
        }
    }
}
