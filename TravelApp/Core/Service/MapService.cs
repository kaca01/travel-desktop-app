using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Service
{
    public class MapService
    {
        public static (double Latitude, double Longitude) GetCoordinates(string address, string apiKey)
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
    }
}
