using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class HistoryUser
{
    public int IdMusic { get; set; }

    public int IdUser { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public virtual Music IdMusicNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
