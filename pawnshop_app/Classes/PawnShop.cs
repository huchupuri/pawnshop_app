using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pawnshop_app.Classes
{
    public class Pawnshop
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Location")]
        public string Location { get; set; }

        [JsonPropertyName("Rating")]
        public double Rating { get; set; }

        [JsonPropertyName("Items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("EstablishedYear")]
        public int EstablishedYear { get; set; }
    }
}
