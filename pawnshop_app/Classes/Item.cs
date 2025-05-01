using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawnshop_app.Classes
{
    public class Item
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int EstimatedValue { get; set; }
        public string Condition { get; set; }
    }
}
