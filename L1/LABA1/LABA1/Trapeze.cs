using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA1
{
    internal class Trapeze
    {
        // трапеция из оси Ox и параболы y = a - b*x^2

        public double  a, b, x01 ,x02;

        public Trapeze(double a, double b)                      // задание объкта  - трапеция 
        {
            this.a = a;
            this.b = b;
            this.x01 = -1 * Math.Sqrt(a / b);                   //Вычисление  1 точеки пересечения с Ox
            this.x02 = Math.Sqrt(a / b);                        //Вычисление  2 точеки пересечения с Ox

        }
        public Trapeze()                // параметры трапеции по умолчанию
        {
            a = 4;              
            b = 1;
            x01 = -1 * Math.Sqrt(a / b);
            x02 = Math.Sqrt(a / b);
        }

        public bool IsPossible()                                    // проверка на правильность существования фигуры
        {
            return a > 0 && b > 0 || a < 0 && b < 0;                //    1) либо парабола смотрит вниз и находится нод осью Ox 
        }                                                           //    2) либо наоборот

        public double Area()                            // вычисление площади с помощью интегрального метода
        {      
            double area = 0;                        // значение площади

            if (a > 0 && b > 0)                                 // для 1) типа тропеции
            {   
                for (double pos = x01; pos < x02 ; pos+= 0.001 )                           // идём с шагом по оси Х и вычилсяя значения 
                {
                area += a - b * pos * pos;                                                  // суммируем их в площадь и в конце 
                }                                  
                area = area*0.001;                                                          // и умножаем на шаг получая площадь с точность шага = 0.001                        
            }
                
            else if (a < 0 && b < 0)                            // аналогично для 2) типа     
            {
                for (double pos = x01; pos < x02; pos += 0.001)
                {
                    area += a - b * pos * pos;
                }
                area = -area * 0.001 ;                                  // умножение на минус 1 т.к. все рассматриваемые у отрицательны на отрезке

            }

            return area;
        }

        public double Long()                // вычисление стороны
        {
            return Math.Abs(x01 - x02);
        }

        public double Perimeter()           // вычисление периметра
        {
            double length = 0, y0;                          // длина и некая точка у0 при точке pos
            double temp = a - b * x01 * x01;                // первая точка у0

            for (double pos = x01 + 0.001; pos < 0; pos += 0.001)           // идём по параболе слева на право до половины с шагом = 0.001
            {                                                           // чтобы посчитать длину дуги делим её на отрезки
                y0 = a - b * pos * pos;                                 //считаем моментальную точку у0
                length += Math.Sqrt( (y0 - temp)* (y0 - temp) + 0.001*0.001 );          // используя теорему пифагора  добавляем к длинне маленькйи отрезок дуги
                temp = y0;
            }
            return length*2 + Long();           // умножаем длину половины параболы на 2  и прибовляем длину единственной строны
        }

        public bool IsPointExists(double x, double y)     // проверка точки с координатами х и у на принадлежность трапеции 
        {
            bool resalt = false;
            if (x>= x01 && x<= x02 )                  // икс находится между крайними точками трапеции?
            {
                if (a > 0 && b > 0)                             // 1 тип - ветви вниз, вершины выше Ох
                {
                    resalt = y >= 0 && y < (a - b * x * x);                    // игрик должен быть выше Ох и меньше у функции в х
                }
                if (a < 0 && b < 0)                                         // 2 тип - ветви вверх, вершина ниже Ох
                {
                    resalt = y<=0 && y > (a - b * x * x);               // игрик должен быть ниже Ох и больше у функции в х
                }
            }
            return resalt;
        }
    }
}
