using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelOgVVS
{
    public class Indentation
    {
        public static List<string> Complains { get; set; } = new List<string>();

        public static void ColorMessage(ConsoleColor color, string message, bool gap)
        {
            Console.ForegroundColor = color;

            if (gap)
            {
                Console.WriteLine(message);
            }
            else
                Console.Write(message);

            Console.ResetColor();
        }

        public static int ValidNumberInputMinimum(string number, int minimumNum)
        {
            bool isValid = int.TryParse(number, out int num);


            while (!isValid || num == 0 || num < minimumNum)
            {
                ColorMessage(ConsoleColor.Red, $"Enter correct Input (Minimum {minimumNum}) : -> ", false);

                bool validNow = int.TryParse(Console.ReadLine(), out int num2);

                if (validNow && num2 != 0 && num2 >= minimumNum)
                    return num2;
                else
                    continue;
            }


            return num;
        }

        public static int ValidNumberInputMaximum(string number, int maximumNum)
        {
            bool isValid = int.TryParse(number, out int num);


            while (!isValid || num == 0 || num > maximumNum)
            {
                ColorMessage(ConsoleColor.Red, $"Enter correct Input (Minimum '1' Maximum '{maximumNum}') : -> ", false);

                bool validNow = int.TryParse(Console.ReadLine(), out int num2);

                if (validNow && num2 != 0 && num2 <= maximumNum)
                    return num2;
                else
                    continue;
            }


            return num;
        }

        public static string Indent(int number)
        {
            return "".PadLeft(number);
        }

        public static bool GetBoolean(string input)
        {
            do
            {
                if (input.ToLower() == "y" || input.ToLower() == "yes" || input.ToLower() == "ye")
                    return true;

                else if (input.ToLower() == "n" || input.ToLower() == "no")
                    return false;

                Console.Write("Enter correct input. ('y' or 'n') --> ");
                string secondInput = Console.ReadLine();

                if (secondInput.ToLower() == "y" || secondInput.ToLower() == "yes" || secondInput.ToLower() == "ye")
                    return true;

                else if (secondInput.ToLower() == "n" || secondInput.ToLower() == "no")
                    return false;

                else
                    continue;

            } while (true);
        }

        public static void Complain(params string[] complainsByGuest)
        {
           List<string> list = new List<string>();
            list = complainsByGuest.ToList();
            Complains.AddRange(list);
           
        }

    }

}
