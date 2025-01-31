using Microsoft.AspNetCore.Mvc;
using TaskMasterApi.Data.Models;
using Microsoft.Extensions.Options;

namespace TaskMasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendWhatsapController : ControllerBase
    {
        private readonly WhatsapSettings _whatsapSettings;

        public SendWhatsapController(IOptions<WhatsapSettings> whatsapSettings)
        {
            _whatsapSettings = whatsapSettings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> Whatsap(string? url = "6234f6be-5928-4c00-92c9-f8bc9586b782" )
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var whatsapMsg = new WhatsapMessage
                    {
                        messaging_product = "whatsapp",
                        to = _whatsapSettings.To,
                        type = "template",
                        template = new WhatsapTemplate
                        {
                            name = "notificacin",
                            language = new WhatsapTemplateLanguage
                            {
                                code = "es_MX"
                            },
                            components = new List<WhatsapTemplateComponent>
                            {
                                new WhatsapTemplateComponent
                                {
                                    type = "button",
                                    sub_type = "url",
                                    index = 0,
                                    parameters = new List<WhatsapTemplateParameter>
                                    {
                                        new WhatsapTemplateParameter
                                        {
                                            type = "text",
                                            text = url
                                        }
                                    }
                                }
                            }
                        }
                    };


                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _whatsapSettings.Token);
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(_whatsapSettings.Url, whatsapMsg);
                    if (!response.IsSuccessStatusCode){ 
                        return StatusCode(500, $"Ocurrió un error al enviar el whatsap Status code:{response.StatusCode.ToString() + ", Error: " + await response.Content.ReadAsStringAsync()}");
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Ocurrió un error al enviar el whatsap", Error = ex.Message });
            }
        }
    }
}
