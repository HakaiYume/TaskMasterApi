using System;
using System.Collections.Generic;

namespace TaskMasterApi.Data.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
