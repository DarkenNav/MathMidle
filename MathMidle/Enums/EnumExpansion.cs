using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMidle.Enums
{
    public static class EnumExpansion
    {
        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])(value
                    .GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false));
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }
}
