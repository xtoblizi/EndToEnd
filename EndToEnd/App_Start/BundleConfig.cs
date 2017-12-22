﻿using System.Web;
using System.Web.Optimization;

namespace EndToEnd
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
                "~/Content/site.css",
                "~/Content/bootstrap.css"
            ));

                RegisterLayout(bundles);

                RegisterShared(bundles);

                RegisterAccount(bundles);

                RegisterHome(bundles);

                RegisterCharts(bundles);

                RegisterWidgets(bundles);

                RegisterElements(bundles);

                RegisterForms(bundles);

                RegisterTables(bundles);

                RegisterCalendar(bundles);

                RegisterMailbox(bundles);

                RegisterExamples(bundles);

                RegisterDocumentation(bundles);
            }

            private static void RegisterDocumentation(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Documentation/menu").Include(
                    "~/Scripts/Documentation/Documentation-menu.js"));
            }

            private static void RegisterExamples(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Examples/Blank/menu").Include(
                    "~/Scripts/Examples/Blank-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Invoice/menu").Include(
                    "~/Scripts/Examples/Invoice-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Lockscreen/menu").Include(
                    "~/Scripts/Examples/Lockscreen-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Login").Include(
                    "~/Scripts/Examples/Login.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Login/menu").Include(
                    "~/Scripts/Examples/Login-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/P404/menu").Include(
                    "~/Scripts/Examples/P404-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/P500/menu").Include(
                    "~/Scripts/Examples/P500-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace").Include(
                    "~/Scripts/Examples/Pace.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace/menu").Include(
                    "~/Scripts/Examples/Pace-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/ProfileEx/menu").Include(
                    "~/Scripts/Examples/ProfileEx-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Register").Include(
                    "~/Scripts/Examples/Register.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Examples/Register/menu").Include(
                    "~/Scripts/Examples/Register-menu.js"));
            }

            private static void RegisterMailbox(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox").Include(
                    "~/Scripts/Mailbox/Inbox.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox/menu").Include(
                    "~/Scripts/Mailbox/Inbox-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose").Include(
                    "~/Scripts/Mailbox/Compose.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose/menu").Include(
                    "~/Scripts/Mailbox/Compose-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Read/menu").Include(
                    "~/Scripts/Mailbox/Read-menu.js"));
            }

            private static void RegisterCalendar(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Calendar").Include(
                    "~/Scripts/Calendar/Calendar.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Calendar/menu").Include(
                    "~/Scripts/Calendar/Calendar-menu.js"));
            }

            private static void RegisterTables(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Tables/Simple/menu").Include(
                    "~/Scripts/Tables/Simple-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Tables/Data").Include(
                    "~/Scripts/Tables/Data.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Tables/Data/menu").Include(
                    "~/Scripts/Tables/Data-menu.js"));
            }

            private static void RegisterForms(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced").Include(
                    "~/Scripts/Forms/Advanced.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced/menu").Include(
                    "~/Scripts/Forms/Advanced-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors").Include(
                    "~/Scripts/Forms/Editors.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors/menu").Include(
                    "~/Scripts/Forms/Editors-menu.js"));


                bundles.Add(new ScriptBundle("~/Scripts/Forms/General/menu").Include(
                    "~/Scripts/Forms/General-menu.js"));
            }

            private static void RegisterElements(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Elements/Buttons/menu").Include(
                    "~/Scripts/Elements/Buttons-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/General/menu").Include(
                    "~/Scripts/Elements/General-menu.js"));

                bundles.Add(new StyleBundle("~/Styles/Elements/General").Include(
                    "~/Styles/Elements/General.css"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/Icons/menu").Include(
                    "~/Scripts/Elements/Icons-menu.js"));

                bundles.Add(new StyleBundle("~/Styles/Elements/Icons").Include(
                    "~/Styles/Elements/Icons.css"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/Modals/menu").Include(
                    "~/Scripts/Elements/Modals-menu.js"));

                bundles.Add(new StyleBundle("~/Styles/Elements/Modals").Include(
                    "~/Styles/Elements/Modals.css"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders").Include(
                    "~/Scripts/Elements/Sliders.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders/menu").Include(
                    "~/Scripts/Elements/Sliders-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Elements/Timeline/menu").Include(
                    "~/Scripts/Elements/Timeline-menu.js"));
            }

            private static void RegisterWidgets(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Widgets/menu").Include(
                    "~/Scripts/Widgets/Widgets-menu.js"));
            }

            private static void RegisterCharts(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs").Include(
                    "~/Scripts/Charts/ChartsJs.js"));
                bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs/menu").Include(
                    "~/Scripts/Charts/ChartsJs-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris").Include(
                    "~/Scripts/Charts/Morris.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris/menu").Include(
                    "~/Scripts/Charts/Morris-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot").Include(
                    "~/Scripts/Charts/Flot.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot/menu").Include(
                    "~/Scripts/Charts/Flot-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline").Include(
                    "~/Scripts/Charts/Inline.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline/menu").Include(
                    "~/Scripts/Charts/Inline-menu.js"));
            }

            private static void RegisterHome(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1").Include(
                    "~/Scripts/Home/DashboardV1.js"));
                bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1/menu").Include(
                    "~/Scripts/Home/DashboardV1-menu.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2").Include(
                    "~/Scripts/Home/DashboardV2.js"));
                bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2/menu").Include(
                    "~/Scripts/Home/DashboardV2-menu.js"));
            }

            private static void RegisterAccount(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Account/Login").Include(
                    "~/Scripts/Account/Login.js"));

                bundles.Add(new ScriptBundle("~/Scripts/Account/Register").Include(
                    "~/Scripts/Account/Register.js"));
            }

            private static void RegisterShared(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                    "~/Scripts/Shared/_Layout.js"));
            }

            private static void RegisterLayout(BundleCollection bundles)
            {
                // bootstrap
                bundles.Add(new ScriptBundle("~/Theme/bootstrap/js").Include(
                    "~/Theme/bootstrap/js/bootstrap.min.js"));

                bundles.Add(new StyleBundle("~/Theme/bootstrap/css").Include(
                    "~/Theme/bootstrap/css/bootstrap.min.css"));

                // dist
                bundles.Add(new ScriptBundle("~/Theme/dist/js").Include(
                    "~/Theme/dist/js/app.js"));

                bundles.Add(new StyleBundle("~/Theme/dist/css").Include(
                    "~/Theme/dist/css/admin-lte.min.css"));

                bundles.Add(new StyleBundle("~/Theme/dist/css/skins").Include(
                    "~/Theme/dist/css/skins/_all-skins.min.css"));

                // documentation
                bundles.Add(new ScriptBundle("~/Theme/documentation/js").Include(
                    "~/Theme/documentation/js/docs.js"));

                bundles.Add(new StyleBundle("~/Theme/documentation/css").Include(
                    "~/Theme/documentation/css/style.css"));

                // plugins | bootstrap-slider
                bundles.Add(new ScriptBundle("~/Theme/plugins/bootstrap-slider/js").Include(
                    "~/Theme/plugins/bootstrap-slider/js/bootstrap-slider.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/bootstrap-slider/css").Include(
                    "~/Theme/plugins/bootstrap-slider/css/slider.css"));

                // plugins | bootstrap-wysihtml5
                bundles.Add(new ScriptBundle("~/Theme/plugins/bootstrap-wysihtml5/js").Include(
                    "~/Theme/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/bootstrap-wysihtml5/css").Include(
                    "~/Theme/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css"));

                // plugins | chartjs
                bundles.Add(new ScriptBundle("~/Theme/plugins/chartjs/js").Include(
                    "~/Theme/plugins/chartjs/js/chart.min.js"));

                // plugins | ckeditor
                bundles.Add(new ScriptBundle("~/Theme/plugins/ckeditor/js").Include(
                    "~/Theme/plugins/ckeditor/js/ckeditor.js"));

                // plugins | colorpicker
                bundles.Add(new ScriptBundle("~/Theme/plugins/colorpicker/js").Include(
                    "~/Theme/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/colorpicker/css").Include(
                    "~/Theme/plugins/colorpicker/css/bootstrap-colorpicker.css"));

                // plugins | datatables
                bundles.Add(new ScriptBundle("~/Theme/plugins/datatables/js").Include(
                    "~/Theme/plugins/datatables/js/jquery.dataTables.min.js",
                    "~/Theme/plugins/datatables/js/dataTables.bootstrap.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/datatables/css").Include(
                    "~/Theme/plugins/datatables/css/dataTables.bootstrap.css"));

                // plugins | datepicker
                bundles.Add(new ScriptBundle("~/Theme/plugins/datepicker/js").Include(
                    "~/Theme/plugins/datepicker/js/bootstrap-datepicker.js"
                    /*"~/Theme/plugins/datepicker/js/locales/bootstrap-datepicker"*/));

                bundles.Add(new StyleBundle("~/Theme/plugins/datepicker/css").Include(
                    "~/Theme/plugins/datepicker/css/datepicker3.css"));

                // plugins | daterangepicker
                bundles.Add(new ScriptBundle("~/Theme/plugins/daterangepicker/js").Include(
                    "~/Theme/plugins/daterangepicker/js/moment.min.js",
                    "~/Theme/plugins/daterangepicker/js/daterangepicker.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/daterangepicker/css").Include(
                    "~/Theme/plugins/daterangepicker/css/daterangepicker-bs3.css"));

                // plugins | fastclick
                bundles.Add(new ScriptBundle("~/Theme/plugins/fastclick/js").Include(
                    "~/Theme/plugins/fastclick/js/fastclick.min.js"));

                // plugins | flot
                bundles.Add(new ScriptBundle("~/Theme/plugins/flot/js").Include(
                    "~/Theme/plugins/flot/js/jquery.flot.min.js",
                    "~/Theme/plugins/flot/js/jquery.flot.resize.min.js",
                    "~/Theme/plugins/flot/js/jquery.flot.pie.min.js",
                    "~/Theme/plugins/flot/js/jquery.flot.categories.min.js"));

                // plugins | font-awesome
                bundles.Add(new StyleBundle("~/Theme/plugins/font-awesome/css").Include(
                    "~/Theme/plugins/font-awesome/css/font-awesome.min.css"));

                // plugins | fullcalendar
                bundles.Add(new ScriptBundle("~/Theme/plugins/fullcalendar/js").Include(
                    "~/Theme/plugins/fullcalendar/js/fullcalendar.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/fullcalendar/css").Include(
                    "~/Theme/plugins/fullcalendar/css/fullcalendar.min.css"));

                bundles.Add(new StyleBundle("~/Theme/plugins/fullcalendar/css/print").Include(
                    "~/Theme/plugins/fullcalendar/css/print/fullcalendar.print.css"));

                // plugins | icheck
                bundles.Add(new ScriptBundle("~/Theme/plugins/icheck/js").Include(
                    "~/Theme/plugins/icheck/js/icheck.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/icheck/css").Include(
                    "~/Theme/plugins/icheck/css/all.css"));

                bundles.Add(new StyleBundle("~/Theme/plugins/icheck/css/flat").Include(
                    "~/Theme/plugins/icheck/css/flat/flat.css"));

                bundles.Add(new StyleBundle("~/Theme/plugins/icheck/css/sqare/blue").Include(
                    "~/Theme/plugins/icheck/css/sqare/blue.css"));

                // plugins | input-mask
                bundles.Add(new ScriptBundle("~/Theme/plugins/input-mask/js").Include(
                    "~/Theme/plugins/input-mask/js/jquery.inputmask.js",
                    "~/Theme/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                    "~/Theme/plugins/input-mask/js/jquery.inputmask.extensions.js"));

                // plugins | ionicons
                bundles.Add(new StyleBundle("~/Theme/plugins/ionicons/css").Include(
                    "~/Theme/plugins/ionicons/css/ionicons.min.css"));

                // plugins | ionslider
                bundles.Add(new ScriptBundle("~/Theme/plugins/ionslider/js").Include(
                    "~/Theme/plugins/ionslider/js/ion.rangeSlider.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/ionslider/css").Include(
                    "~/Theme/plugins/ionslider/css/ion.rangeSlider.css",
                    "~/Theme/plugins/ionslider/css/ion.rangeSlider.skinNice.css"));

                // plugins | jquery
                bundles.Add(new ScriptBundle("~/Theme/plugins/jquery/js").Include(
                    "~/Theme/plugins/jquery/js/jQuery-2.1.4.min.js"));

                // plugins | jquery-validate
                bundles.Add(new ScriptBundle("~/Theme/plugins/jquery-validate/js").Include(
                    "~/Theme/plugins/jquery-validate/js/jquery.validate*"));

                // plugins | jquery-ui
                bundles.Add(new ScriptBundle("~/Theme/plugins/jquery-ui/js").Include(
                    "~/Theme/plugins/jquery-ui/js/jquery-ui.min.js"));

                // plugins | jvectormap
                bundles.Add(new ScriptBundle("~/Theme/plugins/jvectormap/js").Include(
                    "~/Theme/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                    "~/Theme/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/jvectormap/css").Include(
                    "~/Theme/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));

                // plugins | knob
                bundles.Add(new ScriptBundle("~/Theme/plugins/knob/js").Include(
                    "~/Theme/plugins/knob/js/jquery.knob.js"));

                // plugins | morris
                bundles.Add(new StyleBundle("~/Theme/plugins/morris/css").Include(
                    "~/Theme/plugins/morris/css/morris.css"));

                // plugins | momentjs
                bundles.Add(new ScriptBundle("~/Theme/plugins/momentjs/js").Include(
                    "~/Theme/plugins/momentjs/js/moment.min.js"));

                // plugins | pace
                bundles.Add(new ScriptBundle("~/Theme/plugins/pace/js").Include(
                    "~/Theme/plugins/pace/js/pace.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/pace/css").Include(
                    "~/Theme/plugins/pace/css/pace.min.css"));

                // plugins | slimscroll
                bundles.Add(new ScriptBundle("~/Theme/plugins/slimscroll/js").Include(
                    "~/Theme/plugins/slimscroll/js/jquery.slimscroll.min.js"));

                // plugins | sparkline
                bundles.Add(new ScriptBundle("~/Theme/plugins/sparkline/js").Include(
                    "~/Theme/plugins/sparkline/js/jquery.sparkline.min.js"));

                // plugins | timepicker
                bundles.Add(new ScriptBundle("~/Theme/plugins/timepicker/js").Include(
                    "~/Theme/plugins/timepicker/js/bootstrap-timepicker.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/timepicker/css").Include(
                    "~/Theme/plugins/timepicker/css/bootstrap-timepicker.min.css"));

                // plugins | raphael
                bundles.Add(new ScriptBundle("~/Theme/plugins/raphael/js").Include(
                    "~/Theme/plugins/raphael/js/raphael-min.js"));

                // plugins | select2
                bundles.Add(new ScriptBundle("~/Theme/plugins/select2/js").Include(
                    "~/Theme/plugins/select2/js/select2.full.min.js"));

                bundles.Add(new StyleBundle("~/Theme/plugins/select2/css").Include(
                    "~/Theme/plugins/select2/css/select2.min.css"));

                // plugins | morris
                bundles.Add(new ScriptBundle("~/Theme/plugins/morris/js").Include(
                    "~/Theme/plugins/morris/js/morris.min.js"));



            }
        }
    }
