using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorMatch.Shared.Models
{
	public class UserPreferences
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int IngredientId { get; set; }
		public bool IsSelected { get; set; }
	}
}
