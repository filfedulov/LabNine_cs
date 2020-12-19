namespace Classes.Time
{
    class OperatorInkrement : IForAppendOrTakeAwayTime
    {
        public Time AppendMinutes(Time to, int minutesAdd)
        {
            int hourToMinutesPlusMinutesTo = (to.hours * 60) + to.minutes;
            hourToMinutesPlusMinutesTo++;
            return new Time { Hours = 0, Minutes = hourToMinutesPlusMinutesTo };
        }

        public Time AppendOrTakeAwayTime(Time to, in Time from)
        {
            return null;
        }
    }
}
