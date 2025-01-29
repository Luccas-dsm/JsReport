using Microsoft.AspNetCore.Mvc;
using PocJSReport.Model;
using PocJSReport.Services;
using System.ComponentModel;

namespace PocJSReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportingService;

        public ReportController(IReportService reportingService)
        {
            this.reportingService = reportingService;
        }

        [HttpPost("html-to-pdf")]
        [Description("Converte Html em css, caso o seu arquivo seja um CSHTML é preciso fazer um pré render no seu servidor antes de enviar-lo." +
                    " Pois o JSReport não trabalha com condicionais ou variaveis do CSHTML.")]
        public async Task<IActionResult> HtmlToPdf([FromBody] RequestBody request)
        {               
            var result = await this.reportingService.HtmlToPdf(request);

            return File(result, "application/pdf", "relatorio.pdf");
        }

        [HttpPost("html-to-pdf-byte-array")]
        public async Task<IActionResult> HtmlToPdfByteArray([FromBody] RequestBody request)
        {
            var report = await this.reportingService.HtmlToPdf(request);

            return Ok(report);
        }

    }
}