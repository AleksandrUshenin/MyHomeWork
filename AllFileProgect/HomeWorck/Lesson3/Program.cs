using System;

namespace Lesson3
{
    internal class Program
    {
        /// <summary>
        /// точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WindowWidth = 65;
            Console.BufferWidth = 65;
            Console.WriteLine("\n >===================================<");
            Console.WriteLine("\tВыберите задание");
            Console.WriteLine("\t1 >>> Задание 1");
            Console.WriteLine("\t2 >>> Задание 2");
            Console.WriteLine("\t3 >>> Задание 3");
            Console.WriteLine("\t4 >>> Задание 4");
            Console.WriteLine("\n\t5 >>> Выход");
            Console.WriteLine(" >===================================<");
            Console.Write("\t");
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
            Console.ReadKey();
        }
        /// <summary>
        /// задание 1. вывести по диагонали числа из двухмерного массива 
        /// </summary>
        static void Exercise1()
        {
            Console.WriteLine("\tЗадание №1");
            string Tab = "";
            int[,] numbers = new int[,]
                    { { 0,  1,  2, 3 },
                      { 10, 11, 12, 13 },
                      { 20, 21, 22, 23 },
                      { 30, 31, 32, 33 } };
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                Console.WriteLine($"\t{Tab}{numbers[i, i]}");
                Tab += " ";
            }
        }
        /// <summary>
        /// задание 2. создание телефонной книги. запрашивает имя и телефон или e-mail
        /// </summary>
        static void Exercise2()
        {
            Console.WriteLine("\tЗадание №2");
            string[,] phoneBook = new string[5, 2];
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.Write("\tВведите имя: ");
                phoneBook[i, 0] = Console.ReadLine();
                Console.Write("\tВведите телефон/e-mail: ");
                phoneBook[i, 1] = Console.ReadLine();
            }
            Console.WriteLine("\n\t\tТелефонная книга\n");
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine($"\tName: {phoneBook[i, 0]}   Phone nunber/e-mail: {phoneBook[i, 1]}");
            }
        }
        /// <summary>
        /// задание 3. запросить строку и вывести ее задом на перед
        /// </summary>
        static void Exercise3()
        {
            Console.WriteLine("\tЗадание №2");
            Console.Write("\tВведите строку: ");
            string str = Console.ReadLine();
            Console.Write("\tРезультат: ");
            for (int i = str.Length - 1; i > -1; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// задание 4. со *  Решил сделать так что бы можно было самому расставлять корабли.
        /// </summary>
        static void Exercise4()
        {
            ExerciseClass Ec = new ExerciseClass();
            Console.WriteLine("\tЗадание №2");
            Console.Clear();
            Console.WriteLine("\t  Расcтавьте корабли");
            Ec.VhodvClass();
        }

        
    }
    /// <summary>
    /// выделил целый класс для задания 4
    /// </summary>
    class ExerciseClass
    {
        static bool[,] Free = new bool[10, 10];
        static string[,] pozition = new string[10, 10];// хранит в себе морское поле с кораблями
        static int x = 14;
        static int y = 8;
        static int[,] ship = new int[,] { { 4, 3, 2, 1 }, { 1, 2, 3, 4 } }; // массив хранит в себе количество кораблей и их палубы 
        static int num = 0; // для переключение между типами кораблей
        static bool povorot = false;// для преключения развертки корабля по(горизонтали, вертикали)
        static string[] Upravl = { "Перемешение cтрелками:", "(Вверх,Вниз,Вправо,Влево)", "Enter - подтвердить", "Пробел - Повернуть Корабль" };

        /// <summary>
        /// публичный метод для доступа к класу и запуску задания 4
        /// </summary>
        public void VhodvClass()
        {
            Pole2();
            Pole();
            Select();
        }
        /// <summary>
        /// метод для заполнения клеток где нельзя ставить корабль (вокруг корабля на 1 клетку)
        /// </summary>
        static void Pole4()
        {
            int x1 = (x / 2) - 6;
            int y1 = y - 5;
            for (int i = 0; i < ship[0, num] + 2; i++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if ((x1 > -1) && (x1 < 10) && (y1 > -1) && (y1 < 10))
                    {
                        Free[x1, y1] = false;
                    }
                    if (povorot == false)
                    {
                        y1++;
                    }
                    else
                    {
                        x1++;
                    }
                }
                if (povorot == false)
                {
                    y1 -= 3;
                    x1++;
                }
                else
                {
                    x1 -= 3;
                    y1++;
                }
            }
        }
        /// <summary>
        /// для записи кораблей в массив 
        /// </summary>
        static void Pole3()
        {
            Pole4();
            int x1 = (x / 2) - 5;
            int y1 = y - 4;
            for (int i = 0; i < ship[0, num]; i++)
            {
                if (povorot == false)
                {
                    pozition[x1 + i, y1] = "X";
                    Free[x1 + i, y1] = false;
                }
                else
                {
                    Free[x1, y1 + i] = false;
                    pozition[x1, y1 + i] = "X";
                }
            }
        }
        /// <summary>
        /// для заполнение морского поля знаком '.' 
        /// </summary>
        static void Pole2()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    pozition[i, j] = ".";
                    Free[i, j] = true;
                }
            }
        }
        /// <summary>
        /// метод для вывода состояния клеток true или false
        /// </summary>
        static void PoleFree()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(34 + i * 2, 4 + j);
                    if (Free[i, j])
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
            }
        }
        /// <summary>
        /// для вывода морского поля и кораблей на экран
        /// </summary>
        static void Pole()
        {
            //PoleFree();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(10 + i * 2, 4 + j);
                    Console.Write(pozition[i, j]);
                }
            }
            for (int t = 0; t < 10; t++)
            {
                Console.SetCursorPosition(6, 4 + t);
                Console.WriteLine(t + 1);
                Console.SetCursorPosition(8, 4 + t);
                Console.Write("|");

                Console.SetCursorPosition(30, 4 + t);
                Console.Write("|");

                if (t < Upravl.Length)
                {
                    Console.SetCursorPosition(36, 5 + t);
                    Console.Write(Upravl[t]);
                }
            }
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("А Б В Г Д Е Ж З И К");
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(9 + i, 3);
                Console.Write("_");
                Console.SetCursorPosition(9 + i, 14);
                Console.Write("-");
            }
        }
        /// <summary>
        ///  для навигации по морсому полю (верх, низ, вправо, влево) и для поворота корабля (пробел) для потверждения Enter
        /// </summary>
        static void Select()
        {
            Console.CursorVisible = false;
            do
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if ((consoleKeyInfo.Key == ConsoleKey.DownArrow) && (y < 13))
                {
                    if ((povorot) && (y < (14 - ship[0, num])))
                    {
                        y++;
                    }
                    if (!povorot)
                    {
                        y++;
                    }
                }
                else if ((consoleKeyInfo.Key == ConsoleKey.UpArrow) && ((y != 0) && (y != 4)))
                {
                    y--;
                }
                else if ((consoleKeyInfo.Key == ConsoleKey.RightArrow) && (x < 27))
                {
                    if ((povorot == false) && ((x / 2) - 5 < (10 - ship[0, num])))
                    {
                        x += 2;
                    }
                    if (povorot)
                    {
                        x += 2;
                    }
                }
                else if ((consoleKeyInfo.Key == ConsoleKey.LeftArrow) && (x != 10))
                {
                    x -= 2;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {
                    x = 14;
                    y = 8;
                    if (!povorot)
                    {
                        povorot = true;
                    }
                    else
                    {
                        povorot = false;
                    }
                }
                else if ((consoleKeyInfo.Key == ConsoleKey.Enter) && (Free[x / 2 - 5, y - 4] == true))
                {
                    Pole3();
                    if (ship[1, num] == 1)
                    {
                        num++;
                        if (num > 3)
                        {
                            Console.SetCursorPosition(15, 15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ты молодец!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                    }
                    else
                    {
                        ship[1, num]--;
                    }
                }
                Pole();
                DisplayShip();
            }
            while (true);
        }
        /// <summary>
        /// для отображения текущего корaбля на экран
        /// </summary>
        static void DisplayShip()
        {
            int x2 = x;
            int y2 = y;
            if (povorot == false)
            {
                for (int i = 0; i < ship[0, num]; i++)
                {
                    Console.SetCursorPosition(x2 + i, y);
                    Console.Write("X");
                    x2++;
                }
            }
            else
            {
                for (int i = 0; i < ship[0, num]; i++)
                {
                    Console.SetCursorPosition(x, y + i);
                    Console.Write("X");
                    y2++;
                }
            }
        }
    }
}
