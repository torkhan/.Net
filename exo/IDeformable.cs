using System;
using System.Collections.Generic;
using System.Text;

namespace exo
{
    interface IDeformable
    {
        Figure Deformation(double coeffh, double coefffv);
    }
}
