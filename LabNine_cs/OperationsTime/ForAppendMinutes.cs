using System;

namespace Classes.Time
{
    class ForAppendMinutes : IForAppendOrTakeAwayTime
    {
        public Time AppendMinutes(Time to, int minutesAdd)
        {
            if (minutesAdd < 0)
            {
                Console.WriteLine("\nОтрицательного значения быть не должно.\nОбъект типа Time остается без изменений.");
                return to;
            }
            int hourToMinutesPlusMinutesTo = (to.hours * 60) + to.minutes;
            int resultPlusTime = hourToMinutesPlusMinutesTo + minutesAdd;
            if (resultPlusTime < 0)
                Console.WriteLine("\nОтрицательного значения быть не должно.\nОбъект типа Time остается без изменений.");
            to.hours = 0;
            to.Minutes = resultPlusTime;
            return to;
        }

        public Time AppendOrTakeAwayTime(Time to, in Time from)
        {
            return null;
        }
    }
}
