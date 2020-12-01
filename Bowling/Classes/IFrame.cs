using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public interface IFrame
    {
        List<Roll> Rolls { get; }

        int Score { get; set; }

        bool LastFrame { get; set; }

        void Roll();

        IGenerator Generator { get; set; }
    }
}
