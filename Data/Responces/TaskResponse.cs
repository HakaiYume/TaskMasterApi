using System;

namespace TaskMasterApi.Data.Response
{
    public partial class TaskResponse
    {
        public int IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
