using System.Web;
using System.Web.Optimization;

namespace IssueTracker
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/muuri").Include(
                       "~/Scripts/Muuri.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Muuri.css",
                      "~/Content/site.css"
                      ));

            //Table Responsive Collections
            bundles.Add(new ScriptBundle("~/bundles/tableResponsiveJS").Include(
                      "~/Scripts/select2.min.js",
                      "~/Scripts/tbl_res_main.js",
                      "~/Scripts/perfect-scrollbar.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/tableResponsiveCSS").Include(
                      "~/Content/animate/animate.css",
                      "~/Content/tbl_res_main.css",
                      "~/Content/tbh_res_util.css"
                      ));


        }
    }
}
