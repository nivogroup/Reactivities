using Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContextSeed
    {
		public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				if (!context.Values.Any())
				{
					var valuesData = File.ReadAllText(@"/SeedData/values.json");
					var brands = JsonConvert.DeserializeObject<List<Value>>(valuesData);
					foreach (var item in brands)
					{
						context.Values.Add(item);
					}
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<DataContextSeed>();
				logger.LogError(ex.Message);
			}
		}
	}
}
