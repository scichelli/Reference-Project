namespace Tests.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Core.Domain;
    using Should;

    public class AutoFilledParameterSourceTests
    {
        private readonly AutoFilled _source;

        public AutoFilledParameterSourceTests()
        {
            _source = new AutoFilled();
        }

        public void Should_return_empty_collection_when_test_takes_no_args()
        {
            ParameterSetsFrom("HasNoParameters").ShouldBeEmpty();
        }

        public void Should_build_one_set_of_filled_parameters_when_using_AutoFixture()
        {
            var sets = ParameterSetsFrom("HasThreeParametersAndNoAttributes").ToArray();
            sets.Count().ShouldEqual(1);
            var parametersInTheSet = sets.Single();
            parametersInTheSet.Count().ShouldEqual(3);
        }

        public void Should_build_one_set_of_filled_parameters_from_InputAttribute()
        {
            var sets = ParameterSetsFrom("HasTwoParametersAndOneInputAttribute").ToArray();
            sets.Count().ShouldEqual(1);
            var parametersInTheSet = sets.Single();
            parametersInTheSet.Count().ShouldEqual(2);
        }

        public void Should_build_a_set_of_filled_parameters_for_each_InputAttribute()
        {
            var sets = ParameterSetsFrom("HasOneParameterAndThreeInputAttributes").ToArray();
            sets.Count().ShouldEqual(3);
            foreach (var parametersInTheSet in sets)
            {
                parametersInTheSet.Count().ShouldEqual(1);
            }
        }

        private void HasNoParameters() { }

        private void HasThreeParametersAndNoAttributes(string first, int second, AudioBook third) { }

        [Input(24, "another")]
        private void HasTwoParametersAndOneInputAttribute(int first, string second) { }

        [Input("Smidge")]
        [Input("Aurora")]
        [Input("Agatha")]
        private void HasOneParameterAndThreeInputAttributes(string kitty) { }

        private IEnumerable<object[]> ParameterSetsFrom(string name)
        {
            var method = GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
            return _source.GetParameters(method);
        }
    }
}