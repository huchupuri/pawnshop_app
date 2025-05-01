using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawnshop_app.Classes
{
    public class Pawnshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public List<Item> Items { get; set; }
        public List<Lender> Lenders { get; set; }
        public int EstablishedYear { get; set; }
    }
}
