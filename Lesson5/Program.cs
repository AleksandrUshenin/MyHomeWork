using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lesson5
{
    internal class Program : Common
    {
        static void Main(string[] args)
        {
            Exercise2_StartUpp();
            Console.WindowWidth = 65;
            Console.BufferWidth = 65;
            while (true)
            {
                Console.WriteLine("\n >======================================<");
                Console.WriteLine("\tВыберите задание");
                Console.WriteLine("\t1 >>> Задание 1");
                Console.WriteLine("\t2 >>> Задание 2");
                Console.WriteLine("\t3 >>> Задание 3");
                Console.WriteLine("\t4 >>> Задание 4");
                Console.WriteLine("\t5 >>> Задание 5");
                Console.WriteLine("\n\t6 >>> Выход");
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
                        Task4 task4 = new Task4();
                        task4.Exercise4();
                        break;
                    case "5":
                        Exercise5();
                        break;
                    case "6":
                        Console.Clear();
                        return;
                }
                Console.Clear();
            }
        }
        /// <summary>
        /// задание 1. Запись, чтение из текстового файла
        /// </summary>
        static void Exercise1()
        {
            string command = "";
            string stroka = null;
            string status = null;
            do
            {
                command = MenuExercise(stroka, status, '1');
                switch (command)
                {
                    case "1":
                        Exercise_ReadText(out stroka, "Ввод текста: ");
                        stroka += " ";
                        break;
                    case "2":
                        Exercise_Save(stroka, @"\Exercise1", @"\Data.txt");
                        status = "Файл Сохранен!";
                        break;
                    case "3":
                        if (File.Exists(Directory.GetCurrentDirectory() + @"\Exercise1\Data.txt"))
                        {
                            status = "Файл Удален!";
                            File.Delete(Directory.GetCurrentDirectory() + @"\Exercise1\Data.txt");
                        }
                        stroka = null;
                        break;
                    case "4":
                        stroka = string.Concat(Exercise_Load(out status, Directory.GetCurrentDirectory() + @"\Exercise1\Data.txt"));
                        break;
                }
            }
            while (command != "0");
        }
        /// <summary>
        /// при запуске приложения записывает время в файл
        /// </summary>
        static void Exercise2_StartUpp()
        {
            DateTime dateTime = DateTime.Now;
            Exercise_Save(dateTime.ToString(), @"\Exercise2", @"\startup.txt");
        }
        /// <summary>
        /// выводит последнее время запуска приложения 
        /// </summary>
        static void Exercise2()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tЗадание №2\n");
            Console.WriteLine(" >*************************************************************<");
            Console.WriteLine($"\tПоследний запкск приложения : " +
                $"{Exercise_Load(out string a, Path.Combine(Directory.GetCurrentDirectory(), @"Exercise2\startup.txt")).Last()}");
            Console.ReadKey();
        }
        /// <summary>
        /// запрашиваем числа через пробел от 0 до 255 и записываем их в виде binary в фал
        /// </summary>
        static void Exercise3()
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise3");
            string command = "";
            string stroka = null;
            string status = null;
            string num = "";
            do
            {
                command = MenuExercise(stroka, status, '3');
                switch (command)
                {
                    case "1":
                        Exercise_ReadText(out num, "Введите числа от 0 до 255 через пробел: ");
                        stroka = num;
                        break;
                    case "2":
                        if (num.Split(' ').Count() > 1)
                        {
                            string[] sNum = num.Split(' ');
                            byte[] numbers = new byte[sNum.Length];
                            for (int i = 0; i < numbers.Length; i++)
                            {
                                byte.TryParse(sNum[i], out numbers[i]);
                                Exercise_Save_Binary(numbers, dir, "Binary.bin");
                            }
                        }
                        else
                        {
                            byte.TryParse(num, out byte number);
                            Exercise_Save_Binary(number, dir, "Binary.bin");
                        }
                        status = "Файл Сохранен!";
                        break;
                    case "3":
                        if (File.Exists(dir + @"\Binary.bin"))
                        {
                            status = "Файл Удален!";
                            File.Delete(dir + @"\Binary.bin");
                        }
                        stroka = null;
                        break;
                    case "4":
                        stroka = Exercise_Load_Binary(Path.Combine(dir, "Binary.bin"), out status);
                        break;
                }
            }
            while (command != "0");
        }
        /// <summary>
        /// метод для задания 5. выбираем нужный формат и переходим дальше
        /// </summary>
        static void Exercise5()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tЗадание №5\n");
            Console.WriteLine(" >*************************************************************<");
            Console.WriteLine("\tВыбирите формат: \n\t1 >>> json\n\t2 >>> xml\n\t3 >>> bin\n\t0 >>> выход");
            Console.Write("\tВведите: ");
            string select = Console.ReadLine();
            Exercise5_List(select);
        }
        /// <summary>
        /// меню для задания 5.
        /// </summary>
        /// <param name="format">формат</param>
        static void Exercise5_List(string format)
        {
            ToDoS = new ToDo(null, null);
            string[] title = null;
            string[] isDone = null;
            List<string> oli = new List<string>();
            List<string> ol2 = new List<string>();
            ol2.Add(" ");
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t1 >>> Згрузить задачи");
                Console.WriteLine("\t2 >>> Сохранить задачи");
                Console.WriteLine("\t3 >>> Добавить задачи");
                Console.WriteLine("\t4 >>> Удолить");
                Console.WriteLine("\t5 >>> Вывести на экран список задач");
                Console.WriteLine("\t0 >>> Выход");
                Console.Write("\tВведите: ");
                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        switch (format)
                        {
                            case "1":
                                ExerciseJsonLoad();
                                oli = ToDoS?.Title;
                                ol2 = ToDoS?.IsDone;
                                break;
                            case "2":
                                ExerciseXmlLoad();
                                oli = ToDoS?.Title;
                                ol2 = ToDoS?.IsDone;
                                break;
                            case "3":
                                ExerciseBinLoad();
                                oli = ToDoS?.Title;
                                ol2 = ToDoS?.IsDone;
                                break;
                        }
                        break;
                    case "2":
                        switch (format)
                        {
                            case "1":
                                ExerciseJsonSave(oli, ol2);
                                break;
                            case "2":
                                ExerciseXmlSave(oli, ol2);
                                break;
                            case "3":
                                ExerciseBinSave(oli, ol2);
                                break;
                        }
                        break;
                    case "3":
                        oli.Add(AddLIst());
                        break;
                    case "5":
                        if (ToDoS.Title != null)
                        {
                            PrindToDo();
                        }
                        break;
                    case "0":
                        return;
                }
            }
            while (true);
        }
        /// <summary>
        /// метод для отрисовки задач
        /// </summary>
        static void PrindToDo()
        {
            Console.Clear();
            Console.WriteLine("============ текущие задачи ============");
            for (int i = 0; i < ToDoS.Title.Count; i++)
            {
                Console.WriteLine( i + " " +ToDoS.Title[i]);
            }
            Console.WriteLine("============ выполненые задачи ============");
            foreach (string str in ToDoS.IsDone)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("===========================");
            Console.WriteLine("Ввкдите ноиер задачи для ее перемещения в сделанные задачи");
            Console.WriteLine("Или нажмите 'ентер для выхода");
            int select;
            string sel = Console.ReadLine();
            if (sel != "" && sel != " ")
            {
                int.TryParse(sel, out select);
                if (select > -1 && select <= ToDoS.Title.Count)
                {
                    ToDoS.IsDone.Add(ToDoS.Title[select]);
                    ToDoS.Title.Remove(ToDoS.Title[select]);
                }
            }
        }
        /// <summary>
        /// метод для добавления задач 
        /// </summary>
        /// <returns></returns>
        static string AddLIst()
        {
            Console.Write("Введите Задачу: ");
            string list = Console.ReadLine();
            return list;
        }
        static ToDo ToDoS;
        /// <summary>
        /// метод для сохранения в файд бин
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isDone"></param>
        static void ExerciseBinSave(List<string> title, List<string> isDone)
        {
            string dir = Directory.GetCurrentDirectory() + @"\Exercise5\ListB.bin";
            BinaryFormatter formatter = new BinaryFormatter();
            ToDo toDo = new ToDo(title, isDone);
            using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, toDo);
            }
        }
        /// <summary>
        /// метод для загрузги файла бин
        /// </summary>
        static void ExerciseBinLoad()
        {
            string dir = Directory.GetCurrentDirectory() + @"\Exercise5\ListB.bin";
           //ToDo toDo = new ToDo();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
            {
                ToDo toDo = (ToDo)formatter.Deserialize(fs);
                ToDoS = toDo;
            }
        }
        /// <summary>
        /// метод для сохранения а хмл
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isDone"></param>
        static void ExerciseXmlSave(List<string> title, List<string> isDone)
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise5");
            HaveDir(dir);
            dir = Path.Combine(dir, "ListX.xml");
            File.Delete(dir);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo));
            using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
            {
                ToDo toDo = new ToDo(title, isDone);
                xmlSerializer.Serialize(fs, toDo);
            }
        }
        /// <summary>
        /// метод для загрузки хмл
        /// </summary>
        static void ExerciseXmlLoad()
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise5", "ListX.xml");
            if (File.Exists(dir))
            {
                using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo));
                    ToDo toto = xmlSerializer.Deserialize(fs) as ToDo;
                    ToDoS = toto;
                }
            }
        }
        /// <summary>
        /// метод для сохранения джсон
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isDone"></param>
        static async void ExerciseJsonSave(List<string> title, List<string> isDone)
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise5");
            HaveDir(dir);
            dir = Path.Combine(dir, "List.json");
            using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
            {
                ToDo toDo = new ToDo(title, isDone);
                await JsonSerializer.SerializeAsync<ToDo>(fs, toDo);
            }
        }
        /// <summary>
        /// метод для сохранения джсон
        /// </summary>
        static async void ExerciseJsonLoad()
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "Exercise5", "List.json");
            if (File.Exists(dir))
            {
                string feeee = File.ReadAllText(dir);
                using (FileStream fs = new FileStream(dir, FileMode.OpenOrCreate))
                {
                    ToDo tooo = JsonSerializer.Deserialize<ToDo>(feeee);
                    //ToDo tooo = await JsonSerializer.DeserializeAsync<ToDo>(fs);
                    ToDoS = tooo;
                }
            }
        }
    }
    [Serializable]
    public class ToDo
    {
        public List<string> Title { get; set; }
        public List<string> IsDone { get; set; }
        public ToDo() {  }
        public ToDo(List<string> title2, List<string> isDone2)
        {
            IsDone = isDone2;
            Title = title2;
        }
    }
}
