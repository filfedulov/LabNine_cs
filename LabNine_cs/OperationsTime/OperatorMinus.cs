using System;

namespace Classes.Time
{
    class OperatorMinus : IForAppendOrTakeAwayTime
    {
        public Time AppendOrTakeAwayTime(Time to, in Time from)
        {
            int hourToMinutesPlusMinutesTo = (to.hours * 60) + to.minutes;
            int hourToMinutesPlusMinutesFrom = (from.hours * 60) + from.minutes;
            int resultPlusTime = hourToMinutesPlusMinutesTo - hourToMinutesPlusMinutesFrom;
            if (resultPlusTime < 0)
            {
                Console.WriteLine("\nОтрицательного значения быть не должно.\nОбъект типа Time остается без изменений.");
                return to;
            }
            return new Time { Hours = 0, Minutes = resultPlusTime };
        }

        public Time AppendMinutes(Time to, int minutesAdd)
        {
            return null;
        }
    }
}
