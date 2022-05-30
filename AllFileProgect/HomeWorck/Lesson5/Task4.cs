using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson5
{
    internal class Task4 : Common
    {
        /// <summary>
        /// входная точка для задания 4 
        /// </summary>
        public void Exercise4()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\t\tЗадание №4");
            Console.WriteLine(" >*************************************************************<");
            Console.WriteLine("\tВыбор директории для записе ее в файл");
            Console.ReadLine();
            Console.Clear();

            string dir = Directory.GetCurrentDirectory();
            Exercise4_1(dir);
            Console.CursorVisible = true;
        }
        /// <summary>
        /// поле для хранения результата выбора 
        /// </summary>
        static int y = 0;
        /// <summary>
        /// Собирает информацию о директивах 
        /// </summary>
        /// <param name="dir">имя директивы</param>
        void Exercise4_1(string dir)
        {
            DirectoryInfo dirInf = new DirectoryInfo(dir);
            DirectoryInfo[] allDir = dirInf.GetDirectories();
            string[] dirStr = new string[allDir.Length + 1];
            dirStr[0] = @"\..";
            for (int i = 0; i < allDir.Length; i++)
            {
                dirStr[i + 1] = "⌂ " + allDir[i].Name;
            }
            FileInfo[] fileInf = dirInf.GetFiles();
            Exercise4Print(allDir, fileInf);

            int sel = Select(allDir.Length, dirStr);
            if (sel == 0)
            {
                Exercise4_1(Path.GetFullPath(Path.Combine(dir, @"..")));
                return;
            }
            if (sel > -1)
            {
                sel--;
                Exercise4_1(allDir[sel].FullName);
            }
            if (sel == -2) // f
            {
                Console.Clear();
                PrintDir(dirInf, "", false, "");
                Console.Read();
                Save();
                sel = 0;
            }
        }
        /// <summary>
        /// Выводит список директив и фалов
        /// </summary>
        /// <param name="allDir"></param>
        /// <param name="fileInf"></param>
        void Exercise4Print(DirectoryInfo[] allDir, FileInfo[] fileInf)
        {
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            Console.WriteLine("\t" + @"\..");
            foreach (DirectoryInfo Str in allDir)
            {
                Console.WriteLine("\t⌂ " + Str.Name);
            }
            foreach (FileInfo Str in fileInf)
            {
                Console.WriteLine("\t■ " + Str.Name);
            }
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            Console.WriteLine("\tPress 'q' to exit");
            Console.WriteLine("\tPress 'f' to former trees' dtrectory");
        }
        /// <summary>
        /// для работы меню
        /// </summary>
        /// <param name="end">конец списка директив</param>
        /// <param name="dir">массив директив</param>
        /// <returns>возвращает порядковый номер директивы из dir[]</returns>
        int Select(int end, string[] dir)
        {
            do
            {
                ConsoleKeyInfo infoKey = Console.ReadKey(true);
                switch (infoKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y != 0)
                        {
                            PrintBlack(y, dir[y]);
                            y--;
                            PrintBlue(y, dir[y]);
                        }
                        else
                        {
                            PrintBlue(0, dir[0]);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y != end)
                        {
                            PrintBlack(y, dir[y]);
                            y++;
                            PrintBlue(y, dir[y]);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        int y2 = y;
                        y = 0;
                        return y2;
                    case ConsoleKey.Q:
                        return -1;
                    case ConsoleKey.F:
                        return -2;
                }
            }
            while (true);
            return y;
        }
        /// <summary>
        /// отображение строки с синим фоном
        /// </summary>
        /// <param name="yPoz"></param>
        /// <param name="stroka"></param>
        void PrintBlue(int yPoz, string stroka)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(8, yPoz + 1);
            Console.WriteLine(stroka);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// отображение предыдущей строки с черным фоном
        /// </summary>
        /// <param name="yPoz"></param>
        /// <param name="stroka"></param>
        void PrintBlack(int yPoz, string stroka)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(8, yPoz + 1);
            Console.WriteLine(stroka);
        }
        /// <summary>
        /// вывод дерева директорий
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="indent"></param>
        /// <param name="lastDir"></param>
        /// <param name="filePrint"></param>
        void PrintDir(DirectoryInfo dir, string indent, bool lastDir, string filePrint)
        {
            string print = "";
            Console.Write(indent);
            print += indent;
            Console.Write(lastDir ? " └── " : " ├── ");
            print += lastDir ? " └── " : " ├── ";
            indent += lastDir ? "  " : " │ ";
            Console.WriteLine(dir.Name);
            print += dir.Name;
            listString.Add(print);

            DirectoryInfo[] subDir = dir.GetDirectories();
            for (int i = 0; i < subDir.Length; i++)
            {
                PrintDir(subDir[i], indent, i == subDir.Length - 1, filePrint);
            }
        }
        /// <summary>
        /// список дерева дир для сохранения 
        /// </summary>
        static List<string> listString = new List<string>();
        /// <summary>
        /// сохранение дерева директорий в файл
        /// </summary>
        void Save()
        {
            Console.Clear();
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise4");
            HaveDir(dir);
            foreach (string str in listString)
            {
                Exercise_Save(str, dir, @"\Tree.txt");
            }
            Console.WriteLine("\n\n\tФайл Успешно загружен!");
            Console.ReadKey();
        }
    }
}
