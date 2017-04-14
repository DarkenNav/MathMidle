using MathMidle.Enums;
using MathMidle.Implementation;
using System;

namespace MathMidle
{
    class Program
    {
        static Commands command = Commands.None;
        static NumberList numbers = new NumberList();

        static void Main(string[] args)
        {
            #region Test arguments
            //args = new []{ "-am", "1", "2", "3", "4", "5" };
            //args = new[] { "-am" };
            //args = new[] { "-gm", "1", "2", "3", "3", "3" };
            #endregion 

            if (args.Length == 0)
            {
                Console.Write(ErrorInputMessage(false));
            }
            else
            {
                if (ArgumentsParse(args))
                {
                    Calculate();
                }
            }

            Console.Write("\r\nДля завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void Calculate()
        {
            var result = 0d;
            switch (command)
            {
                case Commands.Algebraic:
                    result = numbers.MidleAlgebraic;
                    break;
                case Commands.Geometric:
                    result = numbers.MidleGeometric;
                    break;
            }
            Console.WriteLine($"Результат: {result.ToString("N2")}");
        }

        private static string ErrorInputMessage(bool withExit = true)
        {
            var am = Commands.Algebraic.GetDescription();
            var gm = Commands.Geometric.GetDescription();

            return string.Format("{0}{1}{2}{3}{4}{5}",
                "Пожалуйста, вызовите программу с одним из следующих аргументов\r\n",
                $"{am} <список чисел> - вычисляет среднее арифметическое для списка чисел\r\n",
                $"Разрешеются только положительные числа. Например: {am} 1 2 3 4 5\r\n",
                $"{gm} <список чисел> - вычисляет среднее арифметическое для списка чисел\r\n",
                $"Разрешеются только положительные числа. Например: {gm} 1 2 3 4 5\r\n",
                (withExit)? $"Для выхода введите {Commands.Exit.GetDescription()}\r\n" : string.Empty
                );
        }

        private static bool ArgumentsParse(string[] args)
        {
            if (args.Length > 0 && CheckCommand(args[0]))
            {
                if (command == Commands.Exit)
                {
                    return false;
                }
                if ((command == Commands.Algebraic || command == Commands.Geometric)
                    && args.Length > 2 && CheckValuesFromCalculate(args))
                {
                    return true;
                }
            }

            Console.Write($"Вы ввели не правильные аргументы\r\n{ErrorInputMessage()}");
            return ArgumentsParse(Console.ReadLine().Split(' '));
        }

        private static bool CheckValuesFromCalculate(string[] args)
        {
            numbers = new NumberList();
            for (var i = 1; i < args.Length; i++)
            {
                if (!numbers.AddWithCheck(args[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckCommand(string check)
        {
            foreach (Commands cmd in Enum.GetValues(typeof(Commands)))
            {
                if (check == cmd.GetDescription())
                {
                    command = cmd;
                    return true;
                }
            }
            return false;
        }
    }
}
