namespace Headspring.Labs.Tests.Domain
{
    using Core.Domain;
    using Ploeh.AutoFixture;
    using Should;

    public class AudioBookTests
    {
        public void Should_sum_chapter_durations_to_find_book_duration()
        {
            var book = new AudioBook();
            book.AddChapter(60);
            book.AddChapter(55);
            book.AddChapter(0);
            book.AddChapter(63);
            book.GetDuration().Display.ShouldEqual("2:58");
        }

        public void Should_put_many_chapters_in_a_book(AudioBook book)
        {
            var fixture = new Fixture();
            fixture.AddManyTo(book.Chapters);
            book.GetDuration().TotalSeconds.ShouldBeGreaterThan(0);
        }
    }
}