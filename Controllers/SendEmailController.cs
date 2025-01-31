using Microsoft.AspNetCore.Mvc;
using TaskMasterApi.Interfaces;
using TaskMasterApi.Data.Models;

namespace TaskMasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _service;

        public SendEmailController(ISendEmailService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmailRequest request)
        {
            try
            {
                _service.SendEmail(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Ocurrió un error al enviar el email", Error = ex.Message });
            }
        }
    }
}
