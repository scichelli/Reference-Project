namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Fixie;
    using Ploeh.AutoFixture.Kernel;

    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            Parameters
                .Add<AutoFilled>();
        }
    }

    public class AutoFilled : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            if (method.HasOrInherits<InputAttribute>())
            {
                return method.GetCustomAttributes<InputAttribute>(true).Select(input => input.Parameters);
            }
            var fixture = new Ploeh.AutoFixture.Fixture();
            return new[] { method.GetParameters().Select(p => Resolve(p, fixture)).ToArray() };
        }

        private object Resolve(ParameterInfo p, Ploeh.AutoFixture.Fixture fixture)
        {
            var context = new SpecimenContext(fixture);
            return context.Resolve(p);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InputAttribute : Attribute
    {
        public InputAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; private set; }
    }
}