using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Configuration.Json;
using System.Collections.Generic;
using System.IO;

namespace DAL
{
    public class ConnectionStringManager
    {

        public string GetConnectionString()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, reloadOnChange:true);
            return builder.Build().GetSection("ConnectionString").GetSection("ConString2").Value;
    
        }

    }
}
