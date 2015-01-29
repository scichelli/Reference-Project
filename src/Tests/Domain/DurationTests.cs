namespace Tests.Domain
{
    using Core.Domain;
    using Should;

    public class DurationTests
    {
        public void Should_split_seconds_into_minutes_and_seconds()
        {
            var duration = new Duration(60);
            duration.Minutes.ShouldEqual(1);
            duration.Seconds.ShouldEqual(0);

            var minutesAndSeconds = new Duration(61);
            minutesAndSeconds.Minutes.ShouldEqual(1);
            minutesAndSeconds.Seconds.ShouldEqual(1);

            var lessThanAMinute = new Duration(45);
            lessThanAMinute.Minutes.ShouldEqual(0);
            lessThanAMinute.Seconds.ShouldEqual(45);

            var zero = new Duration(0);
            zero.Minutes.ShouldEqual(0);
            zero.Seconds.ShouldEqual(0);
        }
    }
}