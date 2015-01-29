namespace Tests.Domain
{
    using Core.Domain;
    using Should;

    public class AudioBookTests
    {
        public void Should_sum_chapter_durations_to_find_book_duration()
        {
            var book = new AudioBook();
            book.Chapters.Add(new AudioChapter(new Duration(60)));
            book.Chapters.Add(new AudioChapter(new Duration(55)));
            book.Chapters.Add(new AudioChapter(new Duration(0)));
            book.Chapters.Add(new AudioChapter(new Duration(63)));
            book.GetDuration().Display.ShouldEqual("2:58");
        }
    }
}