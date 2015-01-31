namespace Tests.Infrastructure
{
    using System.Reflection;
    using Should;

    public class AutoFilledParameterSourceTests
    {
        public void Should_return_empty_collection_when_test_takes_no_args()
        {
            var source = new AutoFilled();
            var results =
                source.GetParameters(GetType()
                    .GetMethod("HasNoParameters", BindingFlags.Instance | BindingFlags.NonPublic));
            results.ShouldBeEmpty();
        }

        private void HasNoParameters()
        { }
    }
}