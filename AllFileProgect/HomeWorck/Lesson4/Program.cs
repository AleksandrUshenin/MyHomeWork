using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 65;
            Console.BufferWidth = 65;
            Console.WriteLine("\n >======================================<");
            Console.WriteLine("\tВыберите задание");
            Console.WriteLine("\t1 >>> Задание 1");
            Console.WriteLine("\t2 >>> Задание 2");
            Console.WriteLine("\t3 >>> Задание 3");
            Console.WriteLine("\t4 >>> Задание 4");
            Console.WriteLine("\n\t5 >>> Выход");
            Console.WriteLine(" >======================================<");
            Console.Write("\tВведите номер задания: ");
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
                    return;
            }
            Main(args);
            //Console.ReadKey(true);
        }
        /// <summary>
        /// Задание 1. Запрашиваеи ФИО и выводим одной строкой 
        /// </summary>
        static void Exercise1()
        {
            Console.WriteLine("\n\tЗадание №1\n");
            string[] User = new string[3];
            string[] FIO = new string[4];
            for (int i = 0; i < FIO.Length; i++)
            {
                Console.WriteLine($"\t  User {i + 1}");
                Console.Write("\tВведите Фамилию: ");
                User[0] = Console.ReadLine(); 
                Console.Write("\tВведите Имя: ");
                User[1] = Console.ReadLine();
                Console.Write("\tВведите Отчество: ");
                User[2] = Console.ReadLine();
                FIO[i] = GetFullName(User[1], User[0], User[2]);
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < FIO.Length; i++)
            {
                Console.WriteLine($"\tUser {i + 1}: {FIO[i]}\n");
            }
        }
        /// <summary>
        /// Метод для задания 1. Принимае ФМО в разных аргументах и возвращающий объединённую строку с ФИО.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns></returns>
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }
        /// <summary>
        /// Задание 2. Запрашиваем числа через пробел и выводим сумму этих чисел и передаем их в Exercise2_1
        /// </summary>
        static void Exercise2()
        {
            Console.WriteLine("\n\tЗадание №2\n");
            Console.Write("\tПолучение суммы чисел\n");
            Console.Write("\tВведите числа через пробел: ");
            Console.WriteLine($"\tРезультат = {Exercise2_1(Console.ReadLine())}");
        }
        /// <summary>
        /// метод для задания 2 принимает на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке.
        /// </summary>
        /// <param name="numbres">строка чисел</param>
        /// <returns></returns>
        static int Exercise2_1(string numbres)
        {
            string[] num = numbres.Split(' ');
            int Sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int.TryParse(num[i], out int Sumer);
                Sum += Sumer;
            }
            return Sum;
        }
        /// <summary>
        /// битовая маска для задания 3 хранит времена года и месяца входящие в это время года 
        /// </summary>
        [Flags]
        enum Seasons
        {
            Winter = 0b_1000_0000_0011, 
            Spring = 0b_0000_0001_1100,
            Summer = 0b_0000_1110_0000,
            Autumn = 0b_0111_0000_0000,
            Error = 0
        }
        /// <summary>
        /// задание 3. запрашиваем месяц и передаем в Exercise3_1
        /// </summary>
        static void Exercise3()
        {
            Console.WriteLine("\n\tЗадание №3\n");
            Console.Write("\tВведите номер месяца: ");
            try
            {
                int month = int.Parse(Console.ReadLine());
                if (month > 0 && month < 13)
                {
                    Console.WriteLine($"\n\tМесяц №{month} это {Exercise3_2(Exercise3_1(month))}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tОшибка: введите число от 1 до 12");
                    Console.ForegroundColor = ConsoleColor.White;
                    Exercise3();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\tОшибка введите корректное чило.");
                Console.ForegroundColor = ConsoleColor.White;
                Exercise3();
            }
        }
        /// <summary>
        /// метод для задания 3. получает месяц и мередает в Exercise3_2 enum Season с временем года 
        /// </summary>
        /// <param name="month">номер месяца</param>
        /// <returns>enum времяни года</returns>
        static Seasons Exercise3_1(int month)
        {
            month--;
            month = 1 << month;
            if ((month & (int)Seasons.Winter) > 0)
            {
                return Seasons.Winter;
            }
            else if ((month & (int)Seasons.Autumn) > 0)
            {
                return Seasons.Autumn;
            }
            else if ((month & (int)Seasons.Summer) > 0)
            {
                return Seasons.Summer;
            }
            else if ((month & (int)Seasons.Spring) > 0)
            {
                return Seasons.Spring;
            }
            return Seasons.Error;
        }
        /// <summary>
        /// метод для задания 3. получает enum и возвращает строку с временем года 
        /// </summary>
        /// <param name="seasons">enum времяни года</param>
        /// <returns>время года в стрке</returns>
        static string Exercise3_2(Seasons seasons)
        {
            //return (seasons.ToString().StartsWith("Wi")) ? "Зима" : (seasons.ToString().StartsWith("Sp")) ? "Весна"  : (seasons.ToString().StartsWith("Su")) ? "Лето" : "Осень";
            return (seasons == Seasons.Winter) ? "Зима" : (seasons == Seasons.Spring) ? "Весна" : (seasons == Seasons.Summer) ? "Лето" : "Осень";
        }
        /// <summary>
        /// Задание 4. получаем число Фибоначчи по формуле  F = F - 1 + F - 2; с использование рекурсии
        /// </summary>
        static void Exercise4()
        {
            Console.WriteLine("\n\tЗадание №4\n");
            Console.Write("\tВвидите число: ");
            int.TryParse(Console.ReadLine(), out int res);
            Console.WriteLine($"\t F = {Exercise4_1(res)}");
        }
        /// <summary>
        /// метод для задания 4. сам метод для вычесления 
        /// </summary>
        /// <param name="fibo">входное число = F</param>
        /// <returns>число Фибоначчи</returns>
        static int Exercise4_1(int fibo)
        {
            if (fibo == 0 || fibo == 1)
            {
                return fibo;
            }
            if (fibo > 0)
            {
                return Exercise4_1(fibo - 1) + Exercise4_1(fibo - 2);
            }
            return 0;
        }
    }
}
