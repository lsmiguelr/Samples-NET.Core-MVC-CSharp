﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using System.Data;
using Stimulsoft.Report.Mvc;

namespace Show_Report_in_the_ViewerFx.Controllers
{
    public class ViewerFxController : Controller
    {
        static ViewerFxController()
        {
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport(int? id)
        {
            // Create the report object
            StiReport report = new StiReport();

            // Load report
            switch (id)
            {
                // Load report snapshot
                case 1:
                    report.LoadDocument(StiMvcViewerFx.MapPath(this, "Reports/SimpleList.mdc"));
                    break;

                // Load report template
                case 2:
                    report.Load(StiMvcViewerFx.MapPath(this, "Reports/TwoSimpleLists.mrt"));
                    break;

                // Load report snapshot
                default:
                    report.LoadDocument(StiMvcViewerFx.MapPath(this, "Reports/SimpleList.mdc"));
                    break;
            }

            // Load data from XML file for report template
            if (!report.IsDocument)
            {
                DataSet data = new DataSet("Demo");
                data.ReadXml(StiMvcViewerFx.MapPath(this, "Reports/Data/Demo.xml"));

                report.RegData(data);
            }

            return StiMvcViewerFx.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiMvcViewerFx.ViewerEventResult(this);
        }
    }
}