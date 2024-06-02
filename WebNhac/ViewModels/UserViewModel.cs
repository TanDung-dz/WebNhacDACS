using WebNhac.Models;

namespace WebNhac.ViewModels
{
    public class UserViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Blog> Blogs { get; set; }
        public User Register { get; set; }
        public List<History> History { get; set; }
        public List<Music> historyMusic { get; set; }
        public List<Singer> singerMusic { get; set; }
        public List<DateTime> historyDate { get; set; }
        public UserViewModel()
        {
            Register = new User();
        }
    }
}
