﻿using System.Web.Optimization;

namespace OMum.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //业务
            bundles.Add(new ScriptBundle("~/bundles/appScripts")
                .IncludeDirectory("~/App/Main/javascript", "*.js", true));
            //基础(not lazyloaded)
            bundles.Add(new ScriptBundle("~/bundles/baseScripts").Include(
                  "~/Abp/Framework/scripts/utils/ie10fix.js",//Abp
                        "~/Scripts/json2.min.js",//Abp

              "~/Vendor/modernizr/modernizr.js",//Abp+A

              "~/Vendor/jquery/dist/jquery.js",//Abp+A

              "~/Vendor/angular/angular.js",//Abp+A
              "~/Vendor/angular-route/angular-route.js",
              "~/Vendor/angular-cookies/angular-cookies.js",
              "~/Vendor/angular-animate/angular-animate.js",//Abp+A
              "~/Vendor/angular-touch/angular-touch.js",
              "~/Vendor/angular-ui-router/release/angular-ui-router.js",//Abp+A
              "~/Vendor/ngstorage/ngStorage.js",
              "~/Vendor/angular-ui-utils/ui-utils.js",//Abp+A
              "~/Vendor/angular-sanitize/angular-sanitize.js",//Abp+A
              "~/Vendor/angular-resource/angular-resource.js",
              "~/Vendor/angular-translate/angular-translate.js",
              "~/Vendor/angular-translate-loader-url/angular-translate-loader-url.js",
              "~/Vendor/angular-translate-loader-static-files/angular-translate-loader-static-files.js",
              "~/Vendor/angular-translate-storage-local/angular-translate-storage-local.js",
              "~/Vendor/angular-translate-storage-cookie/angular-translate-storage-cookie.js",
              "~/Vendor/oclazyload/dist/ocLazyLoad.js",
              "~/Vendor/angular-bootstrap/ui-bootstrap-tpls.js",//Abp+A
              "~/Vendor/angular-loading-bar/build/loading-bar.js",
              "~/Vendor/angular-dynamic-locale/dist/tmhDynamicLocale.js",

                 "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js"
            ));
            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );
        }
    }
}