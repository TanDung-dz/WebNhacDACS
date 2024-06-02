using WebNhac.Models;

namespace WebNhac.ViewModels
{
    public class HomeViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<SlideShow> Sliders { get; set; }
        public List<Music> NhacViet { get; set; }
        public List<Music> NhacKpop { get; set; }

        public List<Music> NhacAuMy { get; set; }
        public List<Music> Nhacchill { get; set; }

        public List<Music> BXH { get; set; }
        public List<Singer> bxhSinger { get; set; }

        public List<Mv> MV { get; set; }
   
    }
}
