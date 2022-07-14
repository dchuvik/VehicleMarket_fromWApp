using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public class Weather
    {
        public Weather()
        {
        }
        public string APIResponse { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int AverageMileage { get; set; }
        public int MSRP { get; set; }
        public int Retail { get; set; }
        public int TradeIn { get; set; }




        public void GetAPIResponse(string VIN)
        {
            var key = File.ReadAllText("appsettings.json");
            var APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            var apiCall = $"https://api.carsxe.com/marketvalue?key={APIkey}&vin={VIN}&format=json";

            var client = new HttpClient();

            var response = client.GetStringAsync(apiCall).Result;

            this.APIResponse = response;
        }

        public void GetMake()
        {
            this.Make = JObject.Parse(APIResponse)["make"].ToString();
        }

        public void GetModel()
        {
            this.Model = JObject.Parse(APIResponse)["model"].ToString();
        }

        public void GetModelYear()
        {
            this.ModelYear = int.Parse(JObject.Parse(this.APIResponse)["modelYear"].ToString());
        }

        public void GetAverageMileage()
        {
            this.AverageMileage = int.Parse(JObject.Parse(this.APIResponse)["averageMileage"].ToString());
        }

        public void GetMSRP()
        {
            this.MSRP = int.Parse(JObject.Parse(this.APIResponse)["msrp"].ToString());
        }

        public void GetRetail()
        {
            this.Retail = int.Parse(JObject.Parse(this.APIResponse)["retail"].ToString());
        }

        public void GetTradeIn()
        {
            this.TradeIn = int.Parse(JObject.Parse(this.APIResponse)["tradeIn"].ToString());
        }

        public void GetWeather()
        {
            GetModelYear();
            GetMake();
            GetModel();
            GetAverageMileage();
            GetMSRP();
            GetRetail();
            GetTradeIn();
        }
    }
}
