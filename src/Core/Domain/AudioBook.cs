namespace Core.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class AudioBook
    {
        public AudioBook()
        {
            Chapters = new List<AudioChapter>();
        }

        public IList<AudioChapter> Chapters { get; private set; }

        public Duration GetDuration()
        {
            return Chapters.Sum(x => x.Duration);
        }

        public void AddChapter(int durationTotalSeconds)
        {
            Chapters.Add(new AudioChapter(new Duration(durationTotalSeconds)));
        }
    }

    public class AudioChapter
    {
        public AudioChapter(Duration duration)
        {
            Duration = duration;
        }

        public Duration Duration { get; private set; }
    }
}