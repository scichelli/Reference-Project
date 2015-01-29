﻿namespace Tests.Domain
{
    using Core.Domain;
    using Should;

    public class DurationTests
    {
        [Input(60, 1, 0)]
        [Input(61, 1, 1)]
        [Input(45, 0, 45)]
        [Input(0, 0, 0)]
        public void Should_split_seconds_into_minutes_and_seconds(int totalSeconds, int expectedMinutes, int expectedSeconds)
        {
            var duration = new Duration(totalSeconds);
            duration.Minutes.ShouldEqual(expectedMinutes);
            duration.Seconds.ShouldEqual(expectedSeconds);
        }

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