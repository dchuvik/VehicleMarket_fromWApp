using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //EXERCISE CODE BELOW

            //string key = File.ReadAllText("appsettings.json");
            //string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            //Console.WriteLine("Please enter your zipcode: ");
            //string zipCode = Console.ReadLine();
            
            //string apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIkey}";

            //Console.WriteLine();
            //Console.WriteLine($"It is currently {WeatherMap.GetTemp(apiCall)}°F in your location.");

            //Using Weather Class Object
            var wx = new Weather();

            var cont = true;

            do
            {                
                Console.WriteLine("Please enter your VIN number: ");
                string VIN = Console.ReadLine();

                wx.GetAPIResponse(VIN);
                wx.GetWeather();

                Console.WriteLine($"Year: {wx.ModelYear}");
                Console.WriteLine($"Make: {wx.Make}");
                Console.WriteLine($"Model: {wx.Model}");
                Console.WriteLine($"Average Milage: {wx.AverageMileage} miles");
                Console.WriteLine($"MSRP Value: ${wx.MSRP}");
                Console.WriteLine($"Trade-In Value: ${wx.TradeIn}");
                Console.WriteLine($"Retail Value: ${wx.Retail}");
                Console.WriteLine();
                //Thread.Sleep(5000);

                Console.WriteLine("Would you like to get data for another vehicle?");
                Console.WriteLine("Y or N?");
                var userResponse = Console.ReadLine().ToLower();
                cont = (userResponse == "n") ? false : true;

            } while (cont);
        }
    }
}
