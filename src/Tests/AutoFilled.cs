namespace Headspring.Labs.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Fixie;
    using Ploeh.AutoFixture.Kernel;

    public class AutoFilled : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            if (method.HasOrInherits<InputAttribute>())
                return ParameterSetsFilledFromInputAttributes(method);

            if (method.GetParameters().Any())
                return ParameterSetFilledByAutoFixture(method);

            return NoParameterSets();
        }

        private IEnumerable<object[]> ParameterSetsFilledFromInputAttributes(MethodInfo method)
        {
            var sets = new List<object[]>();
            var parametersToFill = method.GetParameters();
            var numberOfParametersToFill = parametersToFill.Count();

            var inputAttributes = method.GetCustomAttributes<InputAttribute>(true);
            foreach (var inputAttribute in inputAttributes)
            {
                var filledParameters = new List<object>();

                var providedParameters = inputAttribute.Parameters;
                var numberOfProvidedParameters = providedParameters.Count();

                filledParameters.AddRange(providedParameters);

                if (numberOfProvidedParameters < numberOfParametersToFill)
                {
                    filledParameters.AddRange(ParametersFilledByAutoFixture(parametersToFill.Skip(numberOfProvidedParameters)));
                }

                sets.Add(filledParameters.ToArray());
            }

            return sets;
        }

        private IEnumerable<object[]> ParameterSetFilledByAutoFixture(MethodInfo method)
        {
            return new[] { ParametersFilledByAutoFixture(method.GetParameters()) };
        }

        private object[] ParametersFilledByAutoFixture(IEnumerable<ParameterInfo> parameters)
        {
            var fixture = new Ploeh.AutoFixture.Fixture();
            return parameters.Select(p => Resolve(p, fixture)).ToArray();
        }

        private static IEnumerable<object[]> NoParameterSets()
        {
            return Enumerable.Empty<object[]>();
        }

        private object Resolve(ParameterInfo p, Ploeh.AutoFixture.Fixture fixture)
        {
            var context = new SpecimenContext(fixture);
            return context.Resolve(p);
        }
    }
}