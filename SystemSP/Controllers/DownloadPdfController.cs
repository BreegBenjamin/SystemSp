using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace SystemSP.Controllers
{
    public class DownloadPdfController : Controller
    {
        public IActionResult Reporte()
        {

            return new ViewAsPdf("Reporte")
            {
                FileName = "myPdf.pdf",
                PageSize = Size.A4
            };
        }
    }
}
