using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawnshop_app.Classes
{
    public class Lender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public int LoanAmount { get; set; }
        public string LoanStatus { get; set; }
    }
}
