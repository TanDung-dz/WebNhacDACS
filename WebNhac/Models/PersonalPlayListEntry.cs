using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class PersonalPlayListEntry
{
    public int IdMusic { get; set; }

    public int IdPlaylist { get; set; }

    public DateTime? AddDate { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual Music IdMusicNavigation { get; set; } = null!;

    public virtual PersonalPlayList IdPlaylistNavigation { get; set; } = null!;
}
