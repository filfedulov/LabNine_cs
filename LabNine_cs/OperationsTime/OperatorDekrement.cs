using System;

namespace Classes.Time
{
    class OperatorDekrement : IForAppendOrTakeAwayTime
    {
        public Time AppendMinutes(Time to, int minutesAdd)
        {
            int hourToMinutesPlusMinutesTo = (to.hours * 60) + to.minutes;
            hourToMinutesPlusMinutesTo--;
            if (hourToMinutesPlusMinutesTo < 0)
            {
                Console.WriteLine("\nОтрицательного значения быть не должно.\nОбъект типа Time остается без изменений.");
                return to;
            }
            return new Time { Hours = 0, Minutes = hourToMinutesPlusMinutesTo };
        }

        public Time AppendOrTakeAwayTime(Time to, in Time from)
        {
            return null;
        }
    }
}
