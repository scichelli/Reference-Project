namespace Core.Domain
{
    public class Duration
    {
        private readonly int _minutes;
        private readonly int _seconds;

        public Duration(int totalSeconds)
        {
            TotalSeconds = totalSeconds;

            const int secondsPerMinute = 60;
            _minutes = totalSeconds/secondsPerMinute;
            _seconds = totalSeconds%secondsPerMinute;
        }

        public int TotalSeconds { get; private set; }

        public string Display
        {
            get { return string.Format("{0:0}:{1:00}", _minutes, _seconds); }
        }

        public static Duration operator +(Duration a, Duration b)
        {
            return new Duration(a.TotalSeconds + b.TotalSeconds);
        }

        public static implicit operator int(Duration duration)
        {
            return duration.TotalSeconds;
        }

        public static implicit operator Duration(int totalSeconds)
        {
            return new Duration(totalSeconds);
        }
    }
}