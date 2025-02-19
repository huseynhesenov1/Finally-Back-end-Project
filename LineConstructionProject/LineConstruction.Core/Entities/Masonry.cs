using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.Core.Entities
{
    public class Masonry
    {
        public int Id { get; set; }
        public decimal StonePrice { get; set; }
        public decimal CementPrice { get; set; }
        public decimal SandPrice { get; set; }
        public decimal WorkerSalary { get; set; }
    }
}
