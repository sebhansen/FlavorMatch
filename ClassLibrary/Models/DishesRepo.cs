using System.Linq;
using System.Data.SqlClient;
using FlavorMatch.Shared;
using System.Security.Cryptography.X509Certificates;

namespace FlavorMatch.Shared.Models
{
	public class DishesRepo
	{
		DatabaseConnection db = new DatabaseConnection();
		//Get all dishes
		public List<Dishes> GetDishes()
        {
			db.GetDatabaseServer();
			var connectionStringAPI = db.connectionStringAPI;
			List<Dishes> dishes = new List<Dishes>();
			using (SqlConnection connection = new SqlConnection(connectionStringAPI))
			{
				connection.Open();
				string sql = "SELECT * FROM Dishes";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Dishes dish = new Dishes();
							dish.Id = reader.GetInt32(0);
							dish.Name = reader.GetString(1);
							dish.Description = reader.GetString(2);
							dish.Recipe = reader.GetString(3);
							dish.Type = reader.GetString(4);
							dish.Origin = reader.GetString(5);
							dish.Image = reader.GetString(6);
							dishes.Add(dish);
						}
					}
				}
			}
			return dishes;
		}

        public async Task<List<Dishes>> GetAllDishesAsync()
        {
			db.GetDatabaseServer();
			var connectionStringAPI = db.connectionStringAPI;
			List<Dishes> dishes = new List<Dishes>();
            using (SqlConnection conn = new SqlConnection(connectionStringAPI))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Dishes", conn);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Dishes dish = new Dishes();
					dish.Id = reader.GetInt32(0);
					dish.Name = reader.GetString(1);
					dish.Description = reader.GetString(2);
					dish.Recipe = reader.GetString(3);
					dish.Type = reader.GetString(4);
					dish.Origin = reader.GetString(5);
					dish.Image = reader.GetString(6);
					dishes.Add(dish);
                }
            }
            return dishes;
        }

        //Place dishes in an array
        public Dishes[] GetDishesArray()
		{
			List<Dishes> dishesList = new List<Dishes>();
			dishesList = GetDishes();
			Dishes[] dishesArray = dishesList.ToArray();
			return dishesArray;
		}

		public async Task<Dishes[]> GetDishesArrayAsync()
		{
			List<Dishes> dishesList = await GetAllDishesAsync();
			return dishesList.ToArray();
		}
	}
}
