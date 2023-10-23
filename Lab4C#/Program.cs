using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пример с параллельнымм линиями
            Line line = new Line(2, 3, 4, 7);
            Line line1 = new Line(2, 3, 4, 7);

            Console.WriteLine("Уравнение прямой" + line.PrintEquation());

            //Сравнение двух прямых,при false означающий что прямые не параллельны.
            //По заданию если прямые не параллельны то нужно найти и вывести угол между ними.
            if (line | line1)
            {
                Console.WriteLine("Прямые параллельны.");
            }
            else
            {
                Console.WriteLine("Прямые не параллельны.");
                double angle = line % line1;
                Console.WriteLine($"Угол между прямыми: {angle} градусов");
            }

            Console.ReadLine();
        }
    }
}
