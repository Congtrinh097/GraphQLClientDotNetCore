using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLClient.Models
{
    [Serializable]
    public class DataEvent
    {
        public Route routing { get; set; }
    }
    [Serializable]
    public class Route
    {
        public string action { get; set; }
        public string entityId { get; set; }
    }
}
