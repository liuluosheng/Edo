using System.Web;
using System.Web.Optimization;

namespace Edo.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-messages.min.js",
                "~/Scripts/angular-sanitize.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/angularjsui").Include(
             "~/Scripts/ng-scrollbars/*.js",
             "~/Scripts/ng-scrollbars/jquery.mCustomScrollbar.concat.min.js",
             "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
             "~/Scripts/sweetalert.min.js",
             "~/Scripts/sweetalert-angular.js",
             "~/Scripts/angular-toastr.tpls.min.js",
             "~/Scripts/select.min.js",
             "~/Scripts/moment.min.js",
             "~/Scripts/angular-datetimepicker/datetimepicker.js",
             "~/Scripts/angular-datetimepicker/datetimepicker.templates.js",
             "~/Scripts/grid/ngGrid.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/common").Include("~/scripts/common/*.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/angularjsui").Include(
                "~/Content/angular-csp.css",
                "~/Content/ng-scrollbars/jquery.mCustomScrollbar.css",
                "~/Styles/sweetalert.css",
                "~/Content/select.css",
                "~/Content/angular-datetimepicker/datetimepicker.css",
                "~/Content/angular-toastr.min.css",
                "~/Content/grid.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}
