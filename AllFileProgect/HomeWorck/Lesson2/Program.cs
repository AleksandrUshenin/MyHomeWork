using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание");
            Console.WriteLine("1 >>> Задание 1");
            Console.WriteLine("2 >>> Задание 2");
            Console.WriteLine("3 >>> Задание 3");
            Console.WriteLine("4 >>> Задание 4");
            Console.WriteLine("5 >>> Задание 5");
            Console.WriteLine("6 >>> Задание 6");
            Console.WriteLine("7 >>> Выход");
            switch (Console.ReadLine())
            {
                case "1":
                    Exercise1();
                    break;
                case "2":
                    Exercise2();
                    break;
                case "3":
                    Exercise3();
                    break;
                case "4":
                    Exercise4();
                    break;
                case "5":
                    Exercise5();
                    break;
                case "6":
                    Exercise6();
                    break;
                case "7":
                    return;
            }
            Console.ReadKey();
            Console.Clear();
            Main(args);
        }
        static double Temp; // для хранения температуры 
        static bool Razr;
        /// <summary>
        /// Задание 1: выводит среднее число из двух введеных пользователем 
        /// </summary>
        static void Exercise1() // задание 1
        {
            Razr = false;
            Console.Write("Ввидите максимальную температуру за сутки: ");
            string Tmax = Console.ReadLine();
            Console.Write("Ввидите минимальную температуру за сутки: ");
            string Tmin = Console.ReadLine();

            try // для корректной работы программы. при вводе юзером не корректных данных срабатывает catch
            {
                int max = Convert.ToInt32(Tmax);
                int min = Convert.ToInt32(Tmin);
                double result = (double)(max - min) / 2 + min;
                Temp = result;
                Console.WriteLine("Среднесуточная температура = {0}", result);
            }
            catch
            {
                Console.WriteLine("Ошибка: видите корректные числа");
                Exercise1();
            }
        }
        enum Month // для Exercise2
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        /// <summary>
        /// выводит название месяца по его номеру 
        /// </summary>
        static void Exercise2()// задание 2
        {
            Console.Write("Ввидите номер месяца : ");
            string month = Console.ReadLine();
            try
            {
                int numMonth = Convert.ToInt32(month);
                numMonth--;
                if (numMonth > 11)
                {
                    Console.WriteLine("В году 12 месяцев");
                    Exercise2();
                }
                else
                {
                    Console.WriteLine((Month)numMonth);
                }
                if ((numMonth == 11) || (numMonth < 2) || (Temp > 0)) // вывод > Дождливая зима
                {
                    Razr = true;
                    Exercise5();
                }
            }
            catch
            {
                Console.WriteLine("Ошибка: видите корректные числа");
                Exercise2();
            }
        }
        /// <summary>
        /// задание 3 .определение на четное число
        /// </summary>
        static void Exercise3() 
        {
            Console.Write("Ввидите число :");
            string number = Console.ReadLine();
            try
            {
                int num = Convert.ToInt32(number);
                if (num % 2 == 0)
                {
                    Console.WriteLine("Число является чётным");
                }
                else
                {
                    Console.WriteLine("Число не является чётным");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка: видите корректные числа");
                Exercise3();
            }
        }
        /// <summary>
        /// Задание 4. выводит чек.
        /// </summary>
        static void Exercise4() // задание 4
        {
            string city = "Moscow";
            int price = 1300;
            double TotalPrise = 0;
            double percent = 7.6;
            double moneyPer = 0;
            int munberСheck = 465;

            TotalPrise = Math(moneyPer, price, percent);
            DateTime dateTime = DateTime.Now;

            string[] Сheck = new string[] { "    GeekBrains", "   Online school", "     " + city, $"Сheck {munberСheck}", dateTime.ToString(), "-------------------",
                $"C# course .....{price}", "-------------------" ,$"Total:      {TotalPrise}EUR" , $"Percent {percent}%   {moneyPer}EUR"};

            for (int i = 0; i < Сheck.Length; i++)
            {
                Console.WriteLine(Сheck[i]);
            }
        }
        /// <summary>
        /// метод для вычесление процентов.  moneyPer = price / 100 * percent; return price + moneyPer
        /// </summary>
        static double Math(double moneyPer, int price, double percent)
        {
            moneyPer = price / 100 * percent;
            return price + moneyPer;
        }
        static void Exercise5() // задание 5
        {
            if (Razr)
            {
                Console.WriteLine("\nДождливая зима\n");
            }
        }
        enum Teams
        {
            Team1 = 0b_0000_0111,
            Team2 = 0b_0001_1100,
            Team3 = 0b_0111_0000, 
            Team4 = 0b_0101_0101
        }
        enum Weeks 
        {
            Monday = 0b0000001,
            Tuesday = 0b0000010,
            Wednesday = 0b0000100,
            Thursday = 0b0001000,
            Friday = 0b0010000,
            Saturday = 0b0100000,
            Sunday = 0b1000000,
        }
        /// <summary>
        /// задание 6 .выбираем команду и запрашиваеи дни недели по которым она работает 
        /// </summary>
        static void Exercise6() 
        {
            Console.WriteLine("Выбирите команду для просмотра ее графика работы");
            Console.WriteLine("1 >>> Team 1");
            Console.WriteLine("2 >>> Team 2");
            Console.WriteLine("3 >>> Team 3");
            Console.WriteLine("4 >>> Team 4");
            Console.WriteLine("5 >>> Выход");
            switch (Console.ReadLine())
            {
                case "1":
                    Exercise6_1(Teams.Team1);
                    break;
                case "2":
                    Exercise6_1(Teams.Team2);
                    break;
                case "3":
                    Exercise6_1(Teams.Team3);
                    break;
                case "4":
                    Exercise6_1(Teams.Team4);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ошибка!");
                    Console.ReadLine();
                    Exercise6();
                    break;
            }
        }
        /// <summary>
        /// метод для задания 6. получает enum Teams и выводит Weeks по которым работает Teams
        /// </summary>
        /// <param name="nameTeam">enum Teams</param>
        static void Exercise6_1(Teams nameTeam)
        {
            Console.WriteLine($"{nameTeam} работает в:");
            for (int i = 1; i < 127; i = i * 2) 
            {
                if (((int)nameTeam & (int)(Weeks)i) > 0)
                {
                    Console.WriteLine($"\tДень недели : {(Weeks)i}");
                }
            }
            Console.WriteLine();
        }
    }
}
