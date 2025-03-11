using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ScheduleRequest
    {
        public string flag { get; set; }
        public string UserId { get; set; }
    }
    public class ScheduleResponse
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<userList> Users { get; set; }
        public int Length { get; set; }
    }
    public class userList 
    {
        public string Companyid { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }

    }
}
