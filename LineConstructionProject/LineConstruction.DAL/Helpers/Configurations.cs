using Microsoft.Extensions.Configuration;

namespace LineConstruction.DAL.Helpers
{
    public class Configurations
    {

        public static string GetConnectionStr()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "LineConstruction.MVC"));
            configurationManager.AddJsonFile("myCustomSettings.json");
            string? connectionstr = configurationManager.GetSection("LineConnection")["MsSQL"];
            if (connectionstr == null)
            {
                throw new Exception("Connection string nulldur");
            }
            return connectionstr;
        }
    }
}
