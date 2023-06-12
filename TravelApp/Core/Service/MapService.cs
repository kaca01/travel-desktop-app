using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Service
{
    public class MapService
    {
        private const string apiKey = "AuLWjg9zk0YyNOzdddizNFywS-R5879R6PnSVyiT_7T3X3SOnJe8TKz0PvlBO0c3";

        public static (double Latitude, double Longitude) GetCoordinates(string address)
        {
            string apiUrl = $"http://dev.virtualearth.net/REST/v1/Locations?countryRegion=Serbia&addressLine={Uri.EscapeDataString(address)}&key={apiKey}";

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(apiUrl);
                BingMapsApiResponse response = JsonConvert.DeserializeObject<BingMapsApiResponse>(json);

                if (response?.ResourceSets?.Length > 0 && response.ResourceSets[0].Resources?.Length > 0)
                {
                    BingMapsApiResponse.ResourceSet.Resource.Mark point = response.ResourceSets[0].Resources[0].Point;
                    return (point.Coordinates[0], point.Coordinates[1]);
                }
            }

            return (0, 0); // Return default values if address lookup failed
        }

        public static async Task<string> ReverseGeocodeAsync(Location location)
        {
            double latitude = location.Latitude;
            double longitude = location.Longitude;
            string url = $"https://dev.virtualearth.net/REST/v1/Locations/{latitude},{longitude}?o=json&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(json);
                    string address = result.resourceSets[0].resources[0].address.formattedAddress;
                    return address;
                }
            }

            return null;
        }
    }
}
