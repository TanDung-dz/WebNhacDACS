using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class PersonalPlayList
{
    public int IdPlaylist { get; set; }

    public int IdUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<PersonalPlayListEntry> PersonalPlayListEntries { get; set; } = new List<PersonalPlayListEntry>();
}
