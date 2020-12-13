using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisProjectsApp;

namespace SystemSP.Controllers
{
    public class DownloadPdfController : Controller
    {
        public async Task<IActionResult> Reporte()
        {
            var entrada = new SystemSp.Intellengece.WebServiceBusiness.ProjectsApplication(new System.Net.Http.HttpClient() 
            {
                BaseAddress = new Uri("https://localhost:44395/")
            });

            List<ReportApp> result = await entrada.GetReports();

            return new ViewAsPdf("Reporte", result)
            {
                FileName = "reporte.pdf",
                PageSize = Size.A4
            };
        }
    }
}
