using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelApp.Core.Model
{
    public class BingMapsApiResponse
    {
        public class ResourceSet
        {
            public class Resource
            {
                public class Mark
                {
                    public string Type { get; set; }
                    public double[] Coordinates { get; set; }
                }

                public Mark Point { get; set; }
            }

            public Resource[] Resources { get; set; }
        }

        public ResourceSet[] ResourceSets { get; set; }
    }
}
