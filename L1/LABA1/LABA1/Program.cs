using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание: Криволинейная трапеция на заданном интервале, образуемая парабалой и осью ОХ

            Console.WriteLine("Криволинейная трапеция  образуемая парабалой и осью ОХ \n");

            Trapeze t1 = new Trapeze();                 // Трапеция, у которой ветви вниз, вершины выше Ох
            Trapeze t2 = new Trapeze(-4, -1);           // Трапеция, у которой ветви вверх, вершины ниже Ох
            Trapeze t3 = new Trapeze(4, -1);           // Объет у кторого парметры не образуют тропецию

            Console.WriteLine("Функция трапеции заданной по стандарту:");
            Console.WriteLine($"\ty = {t1.a} - ({t1.b})*x^2");
            Console.WriteLine("\tВозможна ли тропеция?:" + t1.IsPossible());
            Console.WriteLine("\tПлощадь:" + t1.Area());
            Console.WriteLine("\tДлина стороны:" + t1.Long() + "\n");

            Console.WriteLine("Функция трапеции заданной с помощью передоваемых параметров a = -4 & b = -1:");
            Console.WriteLine($"\ty = {t2.a} - ({t2.b})*x^2");
            Console.WriteLine("\tВозможна ли тропеция?:" + t2.IsPossible());
            Console.WriteLine("\tПериметр:" + t2.Perimeter());
            Console.WriteLine("\tПринадлежит ли точка (-1, -1):" + t2.IsPointExists(-1, -1));
            Console.WriteLine("\tПринадлежит ли точка (3, -1):" + t2.IsPointExists(3, -1) + "\n");

            Console.WriteLine("Функция трапеции заданной по стандарту:");
            Console.WriteLine($"\ty = {t3.a} - ({t3.b})*x^2");
            Console.WriteLine("\tВозможна ли тропеция?:" + t3.IsPossible() + "\n");

            Console.ReadLine();
        }
    }
}
