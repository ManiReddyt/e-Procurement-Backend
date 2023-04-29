using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class BidderRegisterRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int Experience { get; set; }
        public int SuccessfulTenders { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
