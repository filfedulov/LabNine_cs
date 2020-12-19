namespace Classes.Time
{
    public interface IForAppendOrTakeAwayTime
    {
        Time AppendOrTakeAwayTime(Time to, in Time from);
        Time AppendMinutes(Time to, int minutesAdd = 0);
    }
}
