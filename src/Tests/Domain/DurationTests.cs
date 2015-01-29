namespace Tests.Domain
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
    }
}