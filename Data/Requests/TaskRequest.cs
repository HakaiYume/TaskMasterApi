using System;
using System.ComponentModel.DataAnnotations;

namespace TaskMasterApi.Data.Models
{
    public partial class TaskRequest
    {
        [Required(ErrorMessage = "El campo 'Title' es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo 'Title' no puede exceder los 100 caracteres.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Description' es requerido.")]
        [MaxLength(500, ErrorMessage = "El campo 'Description' no puede exceder los 500 caracteres.")]
        public string Description { get; set; } = null!;
    }
}
