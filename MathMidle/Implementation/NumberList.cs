using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMidle.Implementation
{
    public class NumberList
        : List<int>
    {
        public double MidleAlgebraic
        {
            get
            {
                return this.Sum() / Count;
            }
        }

        public double MidleGeometric
        {
            get
            {
                var mult = 1f;
                ForEach(val => mult *= val);

                return Math.Pow(mult, 1f / Count);
            }
        }
    }
}
