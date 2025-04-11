using System.Drawing;

namespace zadanieschetvertyami
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Дан список точек плоскости с целочисленными координатами. Необходимо определить:

 

1)  номер координатной четверти K, в которой находится больше всего точек;

2)  количество точек в этой четверти M;

3)  точку A в этой четверти, наименее удалённую от осей координат;

4)  расстояние R от этой точки до ближайшей оси.

 

Если в нескольких четвертях расположено одинаковое количество точек, следует выбрать ту четверть, в которой величина R меньше. При равенстве и количества точек, и величины R необходимо выбрать четверть с меньшим номером K. Если в выбранной четверти несколько точек находятся на одинаковом минимальном расстоянии от осей координат, нужно выбрать первую по списку. Точки, хотя бы одна из координат которых равна нулю, считаются не принадлежащими ни одной четверти и не рассматриваются.

 

Напишите эффективную, в том числе по памяти, программу, которая будет решать эту задачу. Перед текстом программы кратко опишите алгоритм решения задачи и укажите используемый язык программирования и его версию.

 

Описание входных данных

В первой строке вводится одно целое положительное число - количество точек N.

Каждая из следующих N строк содержит координаты очередной точки - два целых числа (первое  — координата x, второе  — координата у).

 */

            Console.WriteLine("Введите количество точек");

            int n = Convert.ToInt32(Console.ReadLine());
            Points[] points = new Points[n];


            

           
            int[] chetverti = new int[5]; 
            int[] minR = new int[5]; 
            Points[] blizPoint = new Points[5]; 

            
            for (int i = 1; i <= 4; i++) minR[i] = int.MaxValue;



            Console.WriteLine("Введите координаты точек"); 

            // Считываем координаты точек
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);

                if (x == 0 || y == 0) continue; // Игнорируем точки на осях

                int quadrant = Chetvert(x, y);
                int r = Math.Min(Math.Abs(x), Math.Abs(y)); 

               
                chetverti[quadrant]++;
                if (r < minR[quadrant])
                {
                    minR[quadrant] = r;
                    blizPoint[quadrant] = new Points(x, y);
                }
            }

            // Поиск четверти с максимальным количеством точек
            int maxPointChetvert = 0;
            int maxCount = 0;
            int bestMinR = int.MaxValue;

            for (int q = 1; q <= 4; q++)
            {
                if (chetverti[q] > maxCount ||
                    (chetverti[q] == maxCount && minR[q] < bestMinR))
                {
                    maxCount = chetverti[q];
                    maxPointChetvert = q;
                    bestMinR = minR[q];
                }
            }

            if (maxPointChetvert == 0)
            {
                Console.WriteLine("Нет подходящих точек.");
                return;
            }

            // Вывод результатов
            Points selectedPoint = blizPoint[maxPointChetvert];
            Console.WriteLine($"K = {maxPointChetvert}");
            Console.WriteLine($"M = {maxCount}");
            Console.WriteLine($"A = ({selectedPoint.x}, {selectedPoint.y})");
            Console.WriteLine($"R = {Math.Min(Math.Abs(selectedPoint.x), Math.Abs(selectedPoint.y))}");
        }

        // Функция для определения четверти
        static int Chetvert(int x, int y)
        {
            if (x > 0 && y > 0) return 1;
            if (x < 0 && y > 0) return 2;
            if (x < 0 && y < 0) return 3;
            if (x > 0 && y < 0) return 4;
            return 0; // На случай ошибки
        }


    }
    struct Points
    {
        public int x;
        public int y;

        public Points(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    } 

   
  
    
}

