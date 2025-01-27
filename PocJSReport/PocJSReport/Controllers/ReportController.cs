using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PocJSReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IJsReportMVCService jsReportservice;

        public ReportController(IJsReportMVCService jsReportservice)
        {
            this.jsReportservice = jsReportservice;
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> InvoiceWithHeader()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            HttpContext.JsReportFeature().OnAfterRender((r) => {
                using (var file = System.IO.File.Open("report.pdf", FileMode.Create))
                {
                    r.Content.CopyTo(file);
                }
                r.Content.Seek(0, SeekOrigin.Begin);
            });
            return View(InvoiceModel.Example());
        }
    }
}
