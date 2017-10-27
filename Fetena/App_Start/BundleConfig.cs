using System.Web.Optimization;

namespace Fetena
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/vendor/jquery-{version}.js",
                        "~/Scripts/vendor/bootstrap.js",
                        "~/Scripts/vendor/respond.js",
                        "~/Scripts/vendor/angular.js",
                        "~/Scripts/vendor/angular-animate.js",
                        "~/Scripts/vendor/angular-ui-router.js",
                        "~/Scripts/vendor/angular-ui/ui-bootstrap-tpls.js",
                        "~/Scripts/vendor/lodash.js",
                        "~/Scripts/vendor/highcharts.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/bootstrap-united.css",
                      "~/Content/site.css"));
        }
    }
}
