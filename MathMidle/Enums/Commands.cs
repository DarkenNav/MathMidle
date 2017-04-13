using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMidle.Enums
{
    public enum Commands
    {
        None,
        [Description("-am")]
        Algebraic,
        [Description("-gm")]
        Geometric
    }
}
