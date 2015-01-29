namespace Core.Domain
{
    public class Duration
    {
        public Duration(int totalSeconds)
        {
            TotalSeconds = totalSeconds;
            //math to split seconds into minutes and seconds
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