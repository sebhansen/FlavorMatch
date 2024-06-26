﻿using System.Data.SqlClient;
using System.Linq;

namespace FlavorMatch.Shared.Models
{
    public class IngredientsRepo
	{
		DatabaseConnection db = new DatabaseConnection();
		//Get all ingredients
		public List<Ingredients> GetIngredients()
		{
			db.GetDatabaseServer();
			var connectionString = db.connectionStringAPI;
			List<Ingredients> ingredients = new List<Ingredients>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string sql = "SELECT * FROM Ingredients";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Ingredients ingredient = new Ingredients();
							ingredient.Id = reader.GetInt32(0);
							ingredient.Name = reader.GetString(1);
							ingredient.Description = reader.GetString(2);
							ingredient.Image = reader.GetString(3);
							ingredients.Add(ingredient);
						}
					}
				}
			}
			return ingredients;
		}

		//Place ingredients in an array
		public Ingredients[] GetIngredientsArray()
		{
			List<Ingredients> ingredientsList = new List<Ingredients>();
			ingredientsList = GetIngredients();
			Ingredients[] ingredientsArray = ingredientsList.ToArray();
			return ingredientsArray;
		}
	}
}
