using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class testBien
    {
        public int idBien_B { get; set; }
        public string text { get; set; }
        public IEnumerable<testOption> OPS_return { get; set; }

        public IEnumerable<Option> options { get; set; }
    }
}
