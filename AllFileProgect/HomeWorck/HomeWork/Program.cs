using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string UserName = Console.ReadLine();
            DateTime MyData = new DateTime();
            MyData = DateTime.Now;
            Console.WriteLine("Привет, {0}, сегодня {1}.", UserName, MyData.ToShortDateString());   // получаeм только дату

            Console.ReadLine();
        }
    }
}
