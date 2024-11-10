using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorMatch.Shared.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //Saved favourites
        public List<Dishes> Favourites { get; set; }
        //Filters
        public List<Ingredients> Filters { get; set; }

        public AppUser() 
        {
            Favourites = new List<Dishes>();
            Filters = new List<Ingredients>();
        }
    }
}
