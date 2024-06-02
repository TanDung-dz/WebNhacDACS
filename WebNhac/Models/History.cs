using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class History
{
    public int IdHistory { get; set; }

    public int IdUser { get; set; }

    public int IdMusic { get; set; }

    public DateTime? ListenedDate { get; set; }

    public virtual Music IdMusicNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
