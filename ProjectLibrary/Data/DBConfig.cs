using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjectLibrary.Data
{
	public static class DBConfiguration
	{
		public static string GetConnectionString()
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				 .SetBasePath(Directory.GetCurrentDirectory())
				 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			var configuration = configurationBuilder.Build();
			string connectionString = configuration["DataBase"].["ConnectionString"];
			return connectionString;
		}
	}
}
