using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool AddWithCheck(string value)
        {
            var number = 0;
            if (!int.TryParse(value, out number))
            {
                return false;
            }

            return AddWithCheck(number);
        }

        public bool AddWithCheck(int value)
        {
            if (value > 0)
            {
                Add(value);
                return true;
            }
            return false;
        }
    }
}
