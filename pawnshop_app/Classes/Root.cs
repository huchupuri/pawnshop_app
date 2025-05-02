using pawnshop_app.Classes;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[XmlRoot("root")]
public class Root
{
    [JsonPropertyName("pawnshops")]
    [XmlArray("pawnshops"), XmlArrayItem("pawnshop")]
    public List<Pawnshop> Pawnshops { get; set; }

    [JsonPropertyName("items")]
    [XmlArray("items"), XmlArrayItem("item")]
    public List<Item> Items { get; set; }

    [JsonPropertyName("lenders")]
    [XmlArray("lenders"), XmlArrayItem("lender")]
    public List<Lender> Lenders { get; set; }
}