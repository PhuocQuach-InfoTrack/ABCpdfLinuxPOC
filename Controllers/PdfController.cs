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
        public IActionResult CreatePDFFromHtml(string url = "http://www.google.com/")
        {
            using (var doc = new Doc())
            {
                doc.AddImageUrl(url);
                doc.Save($"./data/output_{DateTime.Now:dd_MM_yyyy_hh_mm_ss}.pdf");
            }

            return Ok("PDF generated successfully.");
        }
    }
}
