using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Time
{
    public class TimeArray
    {
        private int size; 
        public static int count;
        readonly Random random = new Random();
        public Time[] arr;
        public static int avgArithmHours, avgArithmMinutes;
        
        public TimeArray()
        {
            arr = new Time[0];
            count++;
        }

        public TimeArray(int from, int to, int size)
        {
            if (size < 0)
                throw new Exception("\nОтрицательного размера быть не должно.\n");
            arr = new Time[this.size = size];
            count++;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Time();
                arr[i].Hours = random.Next(from, to);
                arr[i].Minutes = random.Next(from, to);
            }
        }

        public TimeArray(int size)
        {
            if (size < 0)
                throw new Exception("\nОтрицательного размера быть не должно.\n");
            arr = new Time[this.size = size];
            count++;
            Console.WriteLine("\nЗаполните поля элементов(объектов) массива типа Time...\n");
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    arr[i] = new Time();
                    Console.WriteLine($"{i + 1}-й Объект: ");
                    Console.Write("kоличество часов объекта: ");
                    arr[i].Hours = int.Parse(Console.ReadLine());
                    Console.Write("kоличество минут объекта: ");
                    arr[i].Minutes = int.Parse(Console.ReadLine());
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine(oex.Message);
                    i -= 1;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                    i -= 1;
                }
            }
        }

        public Time this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }

        public static void AverageArithmetic(TimeArray timeArray)
        {
            avgArithmHours = avgArithmMinutes = 0;
            //int[] averageArithmeticArray = new int[2];
            int hours = 0, minutes = 0;
            for (int i = 0; i < timeArray.arr.Length; i++)
            {
                hours += timeArray.arr[i].hours;
                minutes += timeArray.arr[i].minutes;
            }
            avgArithmHours = hours /= timeArray.arr.Length;
            avgArithmMinutes = minutes /= timeArray.arr.Length;
            Console.WriteLine("Среднее-арифметическое объекта типа Time\n");
            //for (int i = 0; i < averageArithmeticArray.Length; i++)
            //{
            //    if (i == 0)
            //        Console.WriteLine($"Среднее-арифметиское по часам = {averageArithmeticArray[i] = hours}"); 
            //    else
            //        Console.WriteLine($"Среднее-арифметиское по минутам = {averageArithmeticArray[i] = minutes}");

            //}
            Console.WriteLine($"Среднее-арифметиское по часам = {avgArithmHours}");
            Console.WriteLine($"Среднее-арифметиское по минутам = {avgArithmMinutes}");
        }

        public void WriteTimeArray()
        {
            Console.WriteLine($"\nКоличество созданных объектов типа TimeArray = {count}\n");
            for (int i = 0; i < arr.Length; i++)
            {
                Time.WriteTime(in arr[i]);
                Console.WriteLine();
            }
            Console.WriteLine($"\nКоличество созданных объектов типа Time = {Time.count}\n");
        }
    }
}
