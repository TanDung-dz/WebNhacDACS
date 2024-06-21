using WebNhac.Models;

namespace WebNhac.ViewModels
{
    public class AdminViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Music> Musics { get; set; }
        public List<AdminPlayList> AdminPlayLists { get; set; }
        public List<MusicType> MusicTypes { get; set; }
        public List<Mv> mvs { get; set; }
        public List<User> Users { get; set; }
       
    }
}
