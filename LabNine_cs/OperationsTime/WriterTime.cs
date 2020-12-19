using System;

namespace Classes.Time
{
    class WriterTime : IWriteTime
    {
        private int formatWritePartTime, hoursOrminutes;
        string namePartTime = "";

        public void ForWriteTime(int partTime, bool hoursWrite = true)
        {
            if (partTime != 0)
            {
                formatWritePartTime = hoursOrminutes = partTime;
                FormatTime(hoursWrite, namePartTime, formatWritePartTime);
            }
        }

        private void FormatTime(bool hoursWrite, string namePartTime, int formatWritePartTime)
        {
            const string Час = "Час", Часа = "Часа", Часов = "Часов", 
                         Минута = "Минута", Минут = "Минут",  Минуты = "Минуты";
            if (hoursWrite)
                if (formatWritePartTime > 100) formatWritePartTime %= 100;
            if (formatWritePartTime >= 5 && formatWritePartTime <= 20)
            {
                if (hoursWrite)
                    namePartTime = Часов;
                else
                    namePartTime = Минут;
            }
            else
            {
                formatWritePartTime %= 10;
                if (formatWritePartTime == 1)
                {
                    if (hoursWrite)
                        namePartTime = Час;
                    else
                        namePartTime = Минута;
                }
                else if (formatWritePartTime == 0)
                {
                    if (hoursWrite)
                        namePartTime = Часов;
                    else
                        namePartTime = Минут;
                }
                else
                {
                    if (hoursWrite)
                        namePartTime = Часа;
                    else
                        namePartTime = Минуты;
                }
            }
            ConsoleWrite(namePartTime, hoursOrminutes);
        }

        private void ConsoleWrite(string namePartTime, int hoursOrminutes)
        {
            Console.Write($"{hoursOrminutes} {namePartTime}");
        }
    }
}
