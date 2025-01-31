using System.ComponentModel.DataAnnotations;

namespace TaskMasterApi.Data.Models
{
    public partial class SendEmailRequest
    {
        [Required(ErrorMessage = "El campo 'subject' es requerido.")]
        public string subject { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'body' es requerido.")]
        public string body { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'body' es requerido.")]
        public string to { get; set; } = null!;
        
        public string? file { get; set; }
    }
}
