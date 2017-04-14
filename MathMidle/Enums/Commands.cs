using System.ComponentModel;

namespace MathMidle.Enums
{
    public enum Commands
    {
        None,
        [Description("-am")]
        Algebraic,
        [Description("-gm")]
        Geometric,
        [Description("-q")]
        Exit
    }
}
