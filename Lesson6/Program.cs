using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lesson6
{
    internal class Program
    {
        /// <summary>
        /// Входная точка в приложение
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Exercise1();
            Console.ReadLine();
        }
        /// <summary>
        /// иетод для хадания 1. Почти полная копия tasklist  : )   
        /// приработе с дз выявил что используемая память отличается в диспечери и в tasklist. Вопрос: Почему? 
        /// </summary>
        static void Exercise1()
        {
            Process[] proc = Process.GetProcesses();
            int i = 2;
            Console.WriteLine("  Имя                                   ID           № Сеанса           Память");
            Console.WriteLine("=================================== ============== =============== ==================");
            foreach (var str in proc)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(str.ProcessName);
                Console.SetCursorPosition(40, i);
                Console.Write(str.Id);
                Console.SetCursorPosition(55, i);
                Console.Write(str.SessionId);
                Console.SetCursorPosition(70, i);
                Console.Write($"{str.WorkingSet64 / 1024} KB");
                i++;
            }
            Console.Write("\nВведите еомер ID для попытки закрыть процесс: ");
            try
            {
                int select = int.Parse(Console.ReadLine());
                Process vsProcs = Process.GetProcessById(select);
                Console.WriteLine(vsProcs.ProcessName);
                vsProcs.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.Clear();
            Exercise1();
        }
    }
}
