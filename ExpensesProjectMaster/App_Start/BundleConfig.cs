﻿using System.Web;
using System.Web.Optimization;

namespace ExpensesProjectMaster
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/styles.css",
                      "~/Content/Site.css"));


            //Lumino JavaScript Theme files
            bundles.Add(new ScriptBundle("~/bundles/Lumino").Include(
                //"~/Scripts/bootstrap-datepicker.js",
                //"~/Scripts/bootstrap-table.js",
                "~/Scripts/chart.min.js",
                "~/Scripts/easypiechart.js",
                "~/Scripts/html5shiv.js",
                "~/Scripts/lumino.glyphs.js",
                "~/Scripts/respond.min.js"
                ));

            //Lumino CSS Theme Files
            bundles.Add(new StyleBundle("~/Content/Lumino").Include(
            "~/Content/bootstrap-table.css",
            "~/Content/bootstrap-theme.css",
            "~/Content/datepicker.css",
            "~/Content/datepicker3.css",
            "~/Content/Site.css",
            "~/Content/styles.css"
            ));
        }
    }
}