using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorMatch.Shared.Models
{
    public class UserRepo
	{
		public UserRepo() 
		{
		}

		public User GetUser(int id)
		{
			return new User();
		}

		//Take ingredients to saved list
		public void SaveFavourites(int userId, int dishId)
		{

		}

	}
}
