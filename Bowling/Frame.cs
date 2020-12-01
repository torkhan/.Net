using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Frame
    {
        int score;
        List<Roll> rolls;

        public Frame()
        {
        }

        public int Score { get => score; set => score = value; }
        public List<Roll> Rolls { get => rolls; set => rolls = value; }

        public void Roll()
        {

        }
    } 
}
