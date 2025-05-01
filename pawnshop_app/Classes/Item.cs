using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pawnshop_app.Classes
{
    public class Item
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Name")]
        public string Description { get; set; }
        public int EstimatedValue { get; set; }
        public string Condition { get; set; }
    }
}
