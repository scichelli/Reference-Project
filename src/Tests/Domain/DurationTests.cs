namespace Headspring.Labs.Tests.Domain
{
    using Core.Domain;
    using Should;

    public class DurationTests
    {
        [Input(60, "1:00")]
        [Input(61, "1:01")]
        [Input(45, "0:45")]
        [Input(0, "0:00")]
        public void Should_display_duration_as_formatted_minutes_and_seconds(int totalSeconds, string expectedDisplay)
        {
            var duration = new Duration(totalSeconds);
            duration.Display.ShouldEqual(expectedDisplay);
        }

        [Input(1, 1, "0:02")]
        [Input(0, 0, "0:00")]
        [Input(65, 63, "2:08")]
        [Input(65, 0, "1:05")]
        public void Should_sum_durations(int totalSecondsA, int totalSecondsB, string expectedSumDisplay)
        {
            var durationA = new Duration(totalSecondsA);
            var durationB = new Duration(totalSecondsB);
            (durationA + durationB).Display.ShouldEqual(expectedSumDisplay);
        }

        public void Should_add_durations()
        {
            var durationA = new Duration(30);
            var durationB = new Duration(45);
            int sum = durationA + durationB;
            sum.ShouldEqual(30 + 45);
        }
    }
}