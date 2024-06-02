using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Music
{
    public int IdMusic { get; set; }

    public int IdMusictype { get; set; }

    public int IdAdmin { get; set; }

    public int IdSinger { get; set; }

    public int IdAuthor { get; set; }

    public string? Name { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? Thumbnail { get; set; }

    public string? Fille { get; set; }

    public string? Lyric { get; set; }

    public int? CountListened { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public virtual ICollection<AdminPlayListEntry> AdminPlayListEntries { get; set; } = new List<AdminPlayListEntry>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Admin IdAdminNavigation { get; set; } = null!;

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual MusicType IdMusictypeNavigation { get; set; } = null!;

    public virtual Singer IdSingerNavigation { get; set; } = null!;

    public virtual ICollection<PersonalPlayListEntry> PersonalPlayListEntries { get; set; } = new List<PersonalPlayListEntry>();
}
