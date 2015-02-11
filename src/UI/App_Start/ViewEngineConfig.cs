namespace Headspring.Labs.UI
{
    using System.Web.Mvc;
    using Extensions;

    public class ViewEngineConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new FeatureViewLocationRazorViewEngine());
        }
    }
}