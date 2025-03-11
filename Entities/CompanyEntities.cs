using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CompanyEntities
    {
        public string CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<CompanyTypeEntities> Type { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public string HowComeToKnow { get; set; }
        public string Others { get; set; }
        public string Status { get; set; }
        public string CreatedDateTime { get; set; }
        public string Modified { get; set; }
    }
}
