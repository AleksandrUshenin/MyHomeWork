using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;   

namespace Lesson5
{
    internal class Common
    {
        /// <summary>
        /// метод для проверки директории если ее нет то метод ее создаст
        /// </summary>
        /// <param name="directory">полное имя директории</param>
        public static void HaveDir(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        /// <summary>
        /// метод для отрисовки меню ждя заданий 
        /// </summary>
        /// <param name="stroka">строка для вывода содержимого для записи или загружанного из файла</param>
        /// <param name="status">статус работы</param>
        /// <param name="exer">для номера задания</param>
        /// <returns></returns>
        public static string MenuExercise(string stroka, string status, char exer)
        {
            string command = "";
            Console.Clear();
            Console.WriteLine($"\n\t\tЗадание №{exer}\n");
            Console.WriteLine(" >*************************************************************<");
            if (stroka == null)
            {
                Console.WriteLine("\n\tОтсуствуют данные для записи");
            }
            else
            {
                Console.WriteLine($"\n\tТекст: {stroka}");
            }
            Console.WriteLine("\n\t1  >>> Для ввода текста");
            Console.WriteLine("\t2  >>> Для сохранения в файл");
            Console.WriteLine("\t3  >>> Стереть текст/удалить из файла");
            Console.WriteLine("\t4  >>> Загрузить из файла");
            Console.WriteLine("\t0  >>> Для выхода");
            Console.WriteLine($"\n\t{status}\n");
            Console.Write("\tВведите номер: ");
            command = Console.ReadLine();
            status = null;
            return command;
        }
        /// <summary>
        /// запрашивает строку и возвращает ее
        /// </summary>
        /// <param name="Text">возврвщвет запрошенную чтроку</param>
        public static void Exercise_ReadText(out string Text, string textOnDisplay)
        {
            Console.Clear();
            Console.Write($"\n\t{textOnDisplay}");
            Text = Console.ReadLine();
        }
        /// <summary>
        /// метод сохраняет строку в файл
        /// </summary>
        /// <param name="Text">стока для сохранения</param>
        /// <param name="nameDir">имя директории</param>
        /// <param name="nameFile">имя файла</param>
        public static void Exercise_Save(string Text, string nameDir, string nameFile)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), nameDir);
            HaveDir(directory);
            StreamWriter streamWriter = new StreamWriter(directory + nameFile, true);
            streamWriter.WriteLine(Text);
            streamWriter.Close();
        }
        /// <summary>
        /// метод загружает из файла массив сторк
        /// </summary>
        /// <param name="status">статус работы</param>
        /// <param name="dir">имя директории</param>
        /// <returns></returns>
        public static string[] Exercise_Load(out string status, string dir)
        {
            status = null;
            if (File.Exists(dir))
            {
                status = "Файл Загружен!";
                string[] text = File.ReadAllLines(dir);//.ReadAllText(dir);
                if (string.Concat(text) == "")
                    return null;
                else
                    return text;
            }
            return null;
        }
        /// <summary>
        /// сахраняет биты в бинарный файл
        /// </summary>
        /// <param name="numbers">биты</param>
        /// <param name="dir">имя директории</param>
        /// <param name="fileName">имя файла</param>
        public static void Exercise_Save_Binary(byte numbers, string dir, string fileName)
        {
            HaveDir(dir);
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path.Combine(dir, fileName), FileMode.OpenOrCreate)))
            {
                binaryWriter.Write(numbers);
            }
        }
        /// <summary>
        /// перегрузка метода. сахраняет массив бит
        /// </summary>
        /// <param name="numbers">массив для записи</param>
        /// <param name="dir">имя директории</param>
        /// <param name="fileName">имя файла</param>
        public static void Exercise_Save_Binary(byte[] numbers, string dir, string fileName)
        {
            HaveDir(dir);
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path.Combine(dir, fileName), FileMode.OpenOrCreate)))
            {
                binaryWriter.Write(numbers);
            }
        }
        public static void Exercise_Save_Binary(string[] numbers, string dir, string fileName)
        {
            HaveDir(dir);
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path.Combine(dir, fileName), FileMode.OpenOrCreate)))
            {
                foreach (string str in numbers)
                {
                    binaryWriter.Write(str);
                }
            }
        }
        /// <summary>
        /// загружает строку из бинарного файла
        /// </summary>
        /// <param name="fileFullName">имя директории</param>
        /// <param name="status">статус рабты</param>
        /// <returns></returns>
        public static string Exercise_Load_Binary(string fileFullName, out string status)
        {
            string res = "";
            status = null;
            if (File.Exists(fileFullName))
            {
                status = "Файл Загружен!";
                using (BinaryReader binaryReader = new BinaryReader(File.Open(fileFullName, FileMode.Open)))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        res += binaryReader.ReadByte() + " ";
                    }
                }
            }
            return res;
        }
    }
}
