using System.Web;
using System.Web.Optimization;

namespace AnywayStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.2.1.min.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/jquery.nicescroll.min.js",
                        "~/Scripts/jquery.slicknav.min.js",
                        "~/Scripts/jquery.zoom.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/select2.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                    "~/Scripts/owl.carousel.min.js",
                    "~/Scripts/main.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/flaticon.css",
                      "~/Content/css/slicknav.min.css",
                      "~/Content/css/jquery-ui.min.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/style.css"
                      ));
        }
    }
}
