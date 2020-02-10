using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using DAL;

namespace SearchArticle.Models
{

    public class TecDoc
    {

        public string apiKey { get; set; }
        public string jsonService { get; set; }
        public string pictures { get; set; }
        public int providerId { get; set; }
        public string largePictures { get; set; }
        public string thumbnail { get; set; }
        public string jsonServiceUrl { get; set; }

        public void Detail()
        {

            ConnectionTecdocManager connectionTecdocManager = new ConnectionTecdocManager();
            IDictionary details = connectionTecdocManager.GetConnectionTecdocManager();

            apiKey = details["api_key"].ToString();
            jsonService = details["json_service"].ToString();
            jsonServiceUrl = jsonService + "?api_key=" + apiKey;
            providerId = Convert.ToInt32(details["provider_id"]);
            pictures = details["pictures"].ToString();
            thumbnail = details["thumbnail"].ToString();
            largePictures = details["large_pictures"].ToString();

        }

        public static string HttpJsonRequest(string serviceUrl, string jsonParam)
        {
            // Create a new HttpWebRequest to call the given serviceUrl
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(serviceUrl);
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = jsonParam.Length;
            webRequest.Method = "POST";

            // Add jsonParameters to post data stream
            using (StreamWriter postStreamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                postStreamWriter.Write(jsonParam);
                postStreamWriter.Flush();
            }

            // Read stream to get string value
            using(StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                return responseReader.ReadToEnd();
            }

        }


    }
}
