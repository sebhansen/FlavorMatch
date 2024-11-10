using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorMatch.Shared.Models
{
    public class AppUserRepo
	{
		public AppUserRepo() 
		{
		}

		public AppUser GetUser(int id)
		{
			return new AppUser();
		}

		//Take ingredients to saved list
		public void SaveFavourites(int userId, int dishId)
		{

		}

	}
}
