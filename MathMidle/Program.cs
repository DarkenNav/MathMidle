using MathMidle.Enums;
using MathMidle.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMidle
{
    class Program
    {
        static Commands command = Commands.None;
        static NumberList numbers = new NumberList();

        static void Main(string[] args)
        {
            //args = new []{ "-am", "1", "2", "3", "4", "5" };
            //args = new[] { "-gm", "1", "2", "3", "3", "3" };

            if (args.Length == 0)
            {
                Console.Write(ErrorInputMessage());
            }
            else
            {
                ArgumentsParse(args);
                
                switch (command)
                {
                    case Commands.Algebraic:
                        Console.WriteLine($"Результат: {numbers.MidleAlgebraic.ToString("N2")}");
                        break;
                    case Commands.Geometric:
                        Console.WriteLine($"Результат: {numbers.MidleGeometric.ToString("N2")}");
                        break;
                }
            }

            Console.Write("\r\nДля завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static string ErrorInputMessage()
        {
            var am = Commands.Algebraic.GetDescription();
            var gm = Commands.Geometric.GetDescription();

            return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n",
                "Пожалуйста, вызовите программу с одним из следующих аргументов",
                $"{am} <список чисел> - вычисляет среднее арифметическое для списка чисел",
                $"Разрешеются только положительные числа. Например: {am} 1 2 3 4 5",
                $"{gm} <список чисел> - вычисляет среднее арифметическое для списка чисел",
                $"Разрешеются только положительные числа. Например: {gm} 1 2 3 4 5"
                );
        }

        private static void ArgumentsParse(string[] args)
        {
            if (!(args.Length > 2 && CheckCommand(args[0]) && CheckValues(args)))
            {
                Console.Write($"Вы ввели не правильные аргументы\r\n{ErrorInputMessage()}");
                ArgumentsParse(Console.ReadLine().Split(' '));
            }
        }

        private static bool CheckValues(string[] args)
        {
            numbers = new NumberList();
            for (var i = 1; i < args.Length; i++)
            {
                var number = 0;
                if (!int.TryParse(args[i], out number))
                {
                    return false;
                }
                if (number < 1)
                {
                    return false;
                }
                numbers.Add(number);
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
