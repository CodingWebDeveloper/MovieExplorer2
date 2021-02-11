using System.Collections.Generic;

namespace MovieExplorer.Data.Models
{
    public class Town
    {
        public Town()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
