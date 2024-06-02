using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class AdminPlayList
{
    public int IdPlaylist { get; set; }

    public int IdAdmin { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public string? Thumbnail { get; set; }

    public virtual ICollection<AdminPlayListEntry> AdminPlayListEntries { get; set; } = new List<AdminPlayListEntry>();

    public virtual Admin IdAdminNavigation { get; set; } = null!;
}
