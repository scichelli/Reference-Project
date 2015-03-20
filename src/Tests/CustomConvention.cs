namespace Headspring.Labs.Tests
{
    using System;
    using Fixie;
    using UI.DependencyResolution;

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

            ClassExecution
                .CreateInstancePerClass()
                .UsingFactory(GetFromContainer);

            CaseExecution
                .Skip(DeveloperToolsWhenRunningTheWholeSuite);
        }

        private object GetFromContainer(Type testClass)
        {
            var container = IoC.Initialize();
            return container.GetInstance(testClass);
        }

        private bool DeveloperToolsWhenRunningTheWholeSuite(Case testCase)
        {
            var isDeveloperTool = testCase.Method.Has<DeveloperToolAttribute>();
            return isDeveloperTool && TargetMember != testCase.Method;
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

    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class DeveloperToolAttribute : Attribute
    {
    }
}