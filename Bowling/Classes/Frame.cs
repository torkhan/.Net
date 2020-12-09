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
            score = 0;
        }

        public void Roll()
        {
            int randomPin = 0;
            Roll r = null;
            int nbRolls = Rolls.Count;
            if(nbRolls == 0)
            {
                randomPin = Generator.GetRandomPins(10);
            }
            else if(nbRolls == 1)
            {
                Roll r1 = Rolls[0];
                if(r1.Pin == 10 && !LastFrame)
                {
                    throw new Exception("Un seul lance possible");
                }
                else if(r1.Pin == 10 && LastFrame)
                {
                    randomPin = Generator.GetRandomPins(10);
                    r = new Roll(randomPin);
                }
                else
                {
                    randomPin = Generator.GetRandomPins(10 - r1.Pin);
                    r = new Roll(randomPin);            
                }            
            } 
            else if(nbRolls == 2) { 
                if(LastFrame)
                {
                    Roll r1 = Rolls[0];
                    Roll r2 = Rolls[1];
                    if(r2.Pin == 10 || r1.Pin + r2.Pin == 10)
                    {
                        randomPin = Generator.GetRandomPins(10);
                        r = new Roll(randomPin);           
                    }
                    else if(r1.Pin == 10 && r2.Pin < 10)
                    {
                        randomPin = Generator.GetRandomPins(10 - r2.Pin);
                        r = new Roll(randomPin);                      
                    }
                    else
                    {
                        throw new Exception("Lancé impossible");
                    }            
                }
                else
                {
                    throw new Exception("Deux lancés max");
                }
            }
            else
            {
                throw new Exception("Deux lancés max");
            }
            Rolls.Add(r);
            score += randomPin;
        }
    }
}
