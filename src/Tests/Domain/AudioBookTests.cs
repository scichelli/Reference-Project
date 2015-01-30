namespace Tests.Domain
{
    using Core.Domain;
    using Should;
    using Ploeh.AutoFixture;

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

        public void Should_put_many_chapters_in_a_book()
        {
            var fixture = new Fixture();

            var book = new AudioBook();
            fixture.AddManyTo(book.Chapters);
            book.GetDuration().TotalSeconds.ShouldBeGreaterThan(0);
        }
    }
}