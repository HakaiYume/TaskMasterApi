using Microsoft.AspNetCore.Mvc;
using TaskMasterApi.Interfaces;
using TaskMasterApi.Data.Models;

namespace TaskMasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaveDocumentsController : ControllerBase
    {
        private readonly ISaveDocumentsService _service;

        public SaveDocumentsController(ISaveDocumentsService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult SaveDocument([FromForm] IFormFile File)
        {
            try
            {
                _service.SaveDocument(File);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Ocurrió un error al enviar el email", Error = ex.Message });
            }
        }
    }
}
