using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public class Frame : IFrame
    {
        List<Roll> rolls;
        private int score;
        private IGenerator _generator;
        private bool lastFrame;
        public List<Roll> Rolls { get => rolls; set => rolls = value; }
        public int Score { get => score; set => score = value; }
        public bool LastFrame { get => lastFrame; set => lastFrame = value; }
        public IGenerator Generator { get => _generator; set => _generator = value; }

        public Frame(IGenerator g)
        {
            Rolls = new List<Roll>();
            Generator = g;
        }

        public void Roll()
        {
           
            throw new Exception("En cours de dev");
        }
    }
}
