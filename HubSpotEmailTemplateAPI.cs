using System;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FEE.CRM
{
    //https://developers.hubspot.com/docs/methods/templates/post_templates
    class HubSpotEmailTemplateAPI
    {
        //Example Usage and Result
        //Hit this URL with a HTTP method of POST
        //https://api.hubapi.com/content/api/v2/templates

        //and including a request body of

        //{
        //    "category_id": 1(0 - Unmapped.1 - Landing Pages.2 - Email, 3 - Blog Post,4 - Site Page),
        //    "folder": "test",
        //    "is_available_for_new_content": "True",
        //    "template_type": 4,(2 - Email template, 4 - Page template, 6 - Blog template )
        //    "path":"custom/page/examples/a-new-template.html",
        //    "source":"The template source goes here"
        //}
        public HubSpotEmailTemplateAPI() { }
        //https://api.hubapi.com/content/api/v2/templates/5645420155?hapikey=aa11d8c9-718c-4875-ad0d-aa63a4944e21 
        private static readonly string apiKey = ConfigurationManager.AppSettings["HubSpotApiKey"];


        public string CreateHubspotDailyTemplate(string html)
        {
            string file = "custom/email/FEEDaily/FEEdaily-" + DateTime.Now.ToString("MM-dd-yy:hh:mm:ss") + ".html";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.hubapi.com/content/api/v2/templates?hapikey=aa11d8c9-718c-4875-ad0d-aa63a4944e21");
                httpWebRequest.Method = "POST";

                httpWebRequest.Headers.Add("hapikey:aa11d8c9-718c-4875-ad0d-aa63a4944e21");
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"category_id\": 2,\"folder\": \"FEEDaily\",\"is_available_for_new_content\": \"True\",\"template_type\": 2 ,"+ "\"path\":\"" + file + "\"," +"\"source\":" + JsonConvert.SerializeObject(html) + "}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //returning the id of the created Template
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var data = JObject.Parse(result);
                        var id = data["id"].ToString();
                        return id;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string CreateHubspotWeeklyTemplate(string html)
        {
            string file = "custom/email/FEEWeekly/FEEweekly-" + DateTime.Now.ToString("MM-dd-yy:hh:mm:ss") + ".html";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.hubapi.com/content/api/v2/templates?hapikey=aa11d8c9-718c-4875-ad0d-aa63a4944e21");
                httpWebRequest.Method = "POST";

                httpWebRequest.Headers.Add("hapikey:aa11d8c9-718c-4875-ad0d-aa63a4944e21");
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"category_id\": 2,\"folder\": \"FEEWeekly\",\"is_available_for_new_content\": \"True\",\"template_type\": 2 ," + "\"path\":\"" + file + "\"," + "\"source\":" + JsonConvert.SerializeObject(html) + "}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //returning the id of the created Template
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var data = JObject.Parse(result);
                        var id = data["id"].ToString();
                        return id;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }

}
