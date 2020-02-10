using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace DAL
{
    public class ConnectionTecdocManager
    {

        public Dictionary<string, string> GetConnectionTecdocManager()
        {

            Dictionary<string, string> detailsTecDoc = new Dictionary<string, string>();
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, reloadOnChange: true);

            detailsTecDoc.Add("api_key", builder.Build().GetSection("TecDoc").GetSection("API_KEY").Value);
            detailsTecDoc.Add("json_service", builder.Build().GetSection("TecDoc").GetSection("JSON_SERVICE").Value);
            detailsTecDoc.Add("pictures", builder.Build().GetSection("TecDoc").GetSection("LARGE_PICTURES").Value);
            detailsTecDoc.Add("provider_id", builder.Build().GetSection("TecDoc").GetSection("PROVIDER_ID").Value);
            detailsTecDoc.Add("large_pictures", builder.Build().GetSection("TecDoc").GetSection("LARGE_PICTURES").Value);
            detailsTecDoc.Add("thumbnail", builder.Build().GetSection("TecDoc").GetSection("THUMBNAIL_PICTURES").Value);

            return detailsTecDoc;
        }

    }
}
