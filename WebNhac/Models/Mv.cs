using System;
using System.Collections.Generic;

namespace WebNhac.Models;

public partial class Mv
{
    public int IdMv { get; set; }

    public int IdSinger { get; set; }

    public string? Name { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? CountView { get; set; }

    public string? YtbLink { get; set; }

    public int? Order { get; set; }

    public string? Link { get; set; }

    public bool? Hide { get; set; }

    public string? Thumbnail { get; set; }

    public virtual Singer IdSingerNavigation { get; set; } = null!;
}
