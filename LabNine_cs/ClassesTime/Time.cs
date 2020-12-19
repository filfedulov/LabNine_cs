using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Time
{
    public class Time
    {
        public static int count;
        public int minutes;
        public int hours;
        public int Hours
        {
            set
            {
                if (value < 0)
                    Console.WriteLine("\nОтрицательного значения быть не должно, значение данного поля остается быть = 0.\n");
                else
                    hours += value;
            }
            get
            {
                return hours;
            }
        }
        public int Minutes
        {
            set
            {
                if (value < 0)
                    Console.WriteLine("\nОтрицательного значения быть не должно, значение данного поля остается быть = 0.\n");
                else if (value < 60)
                    minutes = value;
                else
                {
                    hours += value / 60;
                    minutes = value % 60;
                }
            }
            get
            {
                return minutes;
            }
        }
        private static IForAppendOrTakeAwayTime iForTime;
        private static IWriteTime iwriteTime;


        public Time(){ count++; }

        public Time(int minutes, int hours)
        {
            count++;
            Minutes = minutes;
            Hours = hours;
        }

        public static Time operator +(Time to, in Time from)
        {
            iForTime = new OperatorPlus();
            return iForTime.AppendOrTakeAwayTime(to, in from);
        }

        public static Time operator -(Time from, in Time what)
        {
            iForTime = new OperatorMinus();
            return iForTime.AppendOrTakeAwayTime(from, in what);
        }

        public static Time operator ++(Time to)
        {
            iForTime = new OperatorInkrement();
            return iForTime.AppendMinutes(to);
        }

        public static Time operator --(Time to)
        {
            iForTime = new OperatorDekrement();
            return iForTime.AppendMinutes(to);
        }

        public static Time AppendMinutes(Time to, int minutesAdd)
        {
            iForTime = new ForAppendMinutes();
            return iForTime.AppendMinutes(to, minutesAdd);
        }

        public Time AppendMinutesForObject(Time to, int minutesAdd)
        {
            iForTime = new ForAppendMinutes();
            return iForTime.AppendMinutes(to, minutesAdd);
        }

        public static implicit operator bool(Time time)
        {
            if (time.Hours == 0 && time.minutes == 0)
                return false;
            else
                return true;
        }

        public static explicit operator int(Time time)
        {
            return time.Hours;
        }

        public static void WriteTime(in Time objectForWrite)
        {
            if (objectForWrite.Hours != 0 || objectForWrite.minutes != 0)
            {
                iwriteTime = new WriterTime();
                Console.Write("Время объекта: ");
                iwriteTime.ForWriteTime(objectForWrite.Hours);
                if (objectForWrite.Hours != 0 && objectForWrite.minutes != 0)
                    Console.Write(" : ");
                iwriteTime.ForWriteTime(objectForWrite.minutes, false);
                Console.WriteLine();
            }
            else
                Console.WriteLine("Время объетка: 0:0");
        }
    }
}
