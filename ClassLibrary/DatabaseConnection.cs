using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorMatch.Shared
{
	public class DatabaseConnection
	{
		public string server = "";

		// Grab the database server from the DatabaseServer.txt file
		public string GetDatabaseServer()
		{
			try
			{
				// Specify the path to the DatabaseServer.txt file
				string filePath = @"C:\Users\Seb H\Documents\GitHub\FlavorMatch\ClassLibrary\DatabaseServer.txt";

				// Check if the file exists
				if (File.Exists(filePath))
				{
					// Read the first line from the file
					server = File.ReadAllText(filePath);

					// Optionally, trim any leading or trailing whitespace
					server = server.Trim();
				}
				else
				{
					Console.WriteLine("DatabaseServer.txt file not found.");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
			return server;
		}
	}
}
