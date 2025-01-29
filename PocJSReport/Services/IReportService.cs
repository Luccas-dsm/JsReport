using PocJSReport.Model;

namespace PocJSReport.Services
{
    public interface IReportService
    {
        /// <summary>
        /// Converte Html em Pdf
        /// </summary>
        /// <param name="request">Html e possiveis parametros caso tenha tags como {{TAG}} sera feito o merge na tag</param>
        /// <returns></returns>
        Task<Stream> HtmlToPdf(RequestBody request);
    }
}
