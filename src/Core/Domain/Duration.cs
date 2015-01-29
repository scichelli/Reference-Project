namespace Core.Domain
{
    public class Duration
    {
        public Duration(int totalSeconds)
        {
            TotalSeconds = totalSeconds;

            const int secondsPerMinute = 60;
            Minutes = totalSeconds/secondsPerMinute;
            Seconds = totalSeconds%secondsPerMinute;
        }

        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public int TotalSeconds { get; private set; }

        public string Display
        {
            get { return string.Format("{0}:{1}", Minutes, Seconds); }
        }

        public static Duration operator +(Duration a, Duration b)
        {
            return new Duration(a.TotalSeconds + b.TotalSeconds);
        }
    }
}