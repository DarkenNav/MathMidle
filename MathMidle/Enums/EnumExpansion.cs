using System;
using System.ComponentModel;

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
