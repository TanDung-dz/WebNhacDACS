using WebNhac.Models;

namespace WebNhac.ViewModels
{
    public class MusicViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Music> Musics { get; set; }
        public List<Music> randomMusics { get; set; }
        public Author Author { get; set; }
        public List<Singer> singerRandom {  get; set; }
    }
}
