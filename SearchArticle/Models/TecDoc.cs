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

        public string ApiKey { get; set; }
        public string JsonService { get; set; }
        public string Pictures { get; set; }
        public int ProviderId { get; set; }
        public string LargePictures { get; set; }
        public string Thumbnail { get; set; }
        public string JsonServiceUrl { get; set; }

        public void Detail()
        {

            ConnectionTecdocManager connectionTecdocManager = new ConnectionTecdocManager();
            IDictionary details = connectionTecdocManager.GetConnectionTecdocManager();

            ApiKey = details["api_key"].ToString();
            JsonService = details["json_service"].ToString();
            JsonServiceUrl = JsonService + "?api_key=" + ApiKey;
            ProviderId = Convert.ToInt32(details["provider_id"]);
            Pictures = details["pictures"].ToString();
            Thumbnail = details["thumbnail"].ToString();
            LargePictures = details["large_pictures"].ToString();

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
