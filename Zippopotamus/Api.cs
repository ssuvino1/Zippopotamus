using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Zippopotamus
{
    public static class ZipCodeApi
    {
        public static ZipData GetDataByCountryAndPostalCode(string country, string postalCode)
        {
            ZipData ret = null;
            try
            {
                string url = string.Format("http://api.zippopotam.us/{0}/{1}", country, postalCode);
                WebClient client = new WebClient();
                string s = client.DownloadString(url);
                ret = JsonConvert.DeserializeObject<ZipData>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        public static CityData GetDataByCountryStateAndCity(string country, string state, string city)
        {
            CityData ret = null;
            try
            {
                string url = string.Format("http://api.zippopotam.us/{0}/{1}/{2}", country, state, city);
                WebClient client = new WebClient();
                string s = client.DownloadString(url);
                ret = JsonConvert.DeserializeObject<CityData>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
    }
    public class CityPlace
    {
        [JsonProperty(PropertyName = "post code")]
        public string PostCode { get; set; }
        [JsonProperty(PropertyName = "place name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public string Long { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public string Lat { get; set; }
    }
    public class ZipPlace : CityPlace
    {
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "state abbreviation")]
        public string Abbr { get; set; }
    }
    public class ZipData
    {
        [JsonProperty(PropertyName = "post code")]
        public string PostCode { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "country abbreviation")]
        public string CountryAbbr { get; set; }
        [JsonProperty(PropertyName = "places")]
        public List<ZipPlace> Places { get; set; }
    }
    public class CityData
    {
        [JsonProperty(PropertyName = "place name")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "country abbreviation")]
        public string CountryAbbr { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "state abbreviation")]
        public string StateAbbr { get; set; }
        [JsonProperty(PropertyName = "places")]
        public List<CityPlace> Places { get; set; }
    }
}
