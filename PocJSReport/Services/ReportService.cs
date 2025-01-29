
using jsreport.Client;
using jsreport.Types;
using PocJSReport.Model;
using System.Diagnostics;

namespace PocJSReport.Services
{
    public class ReportService : IReportService
    {
        const string baseUrl = "http://10.19.1.2:9090/";
        public async Task<Stream> HtmlToPdf(RequestBody request)
        {

            var rs = new ReportingService(baseUrl);
            var result = await rs.RenderAsync(new RenderRequest
            {
                Template = new Template()
                {
                    Content = request.Html,
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.ChromePdf,
                    Chrome = new Chrome
                    {
                        MarginTop = null,
                        MarginBottom = null,
                        MarginLeft = null,
                        MarginRight = null
                    }
                },
                Data = request.Data
            });


            return result.Content;
        }

        /// <summary>
        /// Função para calcular tempo de cada requisição
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Stream> HtmlToPdf_(RequestBody request)
        {
            var stopwatch = Stopwatch.StartNew(); // Inicia a contagem do tempo

            var rs = new ReportingService(baseUrl);
            var result = await rs.RenderAsync(new RenderRequest
            {
                Template = new Template()
                {
                    Content = request.Html,
                    Engine = Engine.Handlebars,
                    Recipe = Recipe.ChromePdf,
                    Chrome = new Chrome
                    {
                        MarginTop = null,
                        MarginBottom = null,
                        MarginLeft = null,
                        MarginRight = null
                    }
                },
                Data = request.Data
            });
            stopwatch.Stop(); // Para a contagem
            Debug.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms"); // Saída no Output do VS

            return result.Content;
        }

    }
}
