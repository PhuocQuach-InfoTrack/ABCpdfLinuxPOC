using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using WebSupergoo.ABCpdf13;

namespace ABCpdfLinuxPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreatePDFFromHtml([FromBody] CreatePdfModel model)
        {
            using (var doc = new Doc())
            {
                if (string.IsNullOrEmpty(model.HtmlString))
                {
                    doc.AddImageUrl(model.Url);
                }
                else
                {
                    doc.AddImageHtml(model.HtmlString);
                }

                doc.Save($"./data/output_{DateTime.Now:dd_MM_yyyy_hh_mm_ss}.pdf");

            }

            return Ok("PDF generated successfully.");
        }
    }

    public class CreatePdfModel
    {
        public string Url { get; set; } = "http://www.google.com/";
        public string HtmlString { get; set; }
    }
}
