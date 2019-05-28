using Newtonsoft.Json;
using RestSharp;
using OxfordDictionary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace OxfordDictionary
{
    public class Library
    {
        public List<string> ParseDictionaryObject(IRestResponse response)
        {
            //Hold the reults definition list. If null its a empty List
            List<String> resultDefinition = new List<string>();

            //Deserialise the Json to POCO objects.Collect the definitions and add the one or many definitions in results list
            var obs = JsonConvert.DeserializeObject<ParseJasonResponse>(response.Content);
            if (obs.Results.Count() > 0)
            {
                foreach (var lexicalentry in obs.Results.First().LexicalEntries)
                {
                    foreach (var enteries in lexicalentry.Entries)
                    {
                        foreach (var sense in enteries.Senses)
                        {
                            resultDefinition.AddRange(sense.Definitions);
                            if (sense.Subsenses != null)
                            {
                                foreach (var subsense in sense.Subsenses)
                                    resultDefinition.AddRange(subsense.Definitions);
                            }
                        }
                    }
                }
            }
            return resultDefinition;

        }

        public IRestResponse GetDictonaryInformation(String word)
        {
            var apiURL = ConfigurationManager.AppSettings["apiURL"];
            var apiKey = ConfigurationManager.AppSettings["apikey"];
            var apiAppID = ConfigurationManager.AppSettings["apiAppID"];
            var apiLangauge = ConfigurationManager.AppSettings["apiLanguage"];
            var tempUrl = string.Format("{0}{1}/{2}{3}", apiURL, apiLangauge, word, "?fields=definitions&strictMatch=false");
            var client = new RestClient(tempUrl);
            client.AddDefaultHeader("app_id", apiAppID);
            client.AddDefaultHeader("app_key", apiKey);
            var request = new RestRequest(tempUrl, Method.GET);
            return client.Execute(request);
        }
    }
}
