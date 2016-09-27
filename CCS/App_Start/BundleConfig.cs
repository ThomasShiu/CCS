using System.Web;
using System.Web.Optimization;

namespace CCS
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-easyui").Include(
                        "~/Content/easyui-1.5/jquery.easyui.min.js"));
            
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // 選單開分頁
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Scripts/CSSHome.js"));
            //easyui
            bundles.Add(new StyleBundle("~/easyui/bootstrap/css").Include("~/Content/easyui/themes/bootstrap/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
            bundles.Add(new StyleBundle("~/easyui/gray/css").Include("~/Content/easyui/themes/gray/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
            bundles.Add(new StyleBundle("~/easyui/metro/css").Include("~/Content/easyui/themes/metro/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
            bundles.Add(new StyleBundle("~/easyui/black/css").Include("~/Content/easyui/themes/black/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
            bundles.Add(new StyleBundle("~/easyui/default/css").Include("~/Content/easyui/themes/default/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
            bundles.Add(new StyleBundle("~/easyui/material/css").Include("~/Content/easyui/themes/material/easyui.css", "~/Content/easyui/themes/color.css", "~/Content/easyui/themes/icon.css"));
        }
    }
}
