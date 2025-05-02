
namespace pawnshop_app.Classes
{
    public class Item
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Condition { get; set; }
        public List<Lender> Lenders { get; set; }
        public List<Pawnshop> Pawnshops { get; set; }
    }
}