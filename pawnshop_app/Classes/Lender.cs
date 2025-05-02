
namespace pawnshop_app.Classes
{
    public class Lender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public decimal LoanAmount { get; set; }
        public string LoanStatus { get; set; }
        public List<Item> Items { get; set; }
        public List<Pawnshop> Pawnshops { get; set; }
    }
}