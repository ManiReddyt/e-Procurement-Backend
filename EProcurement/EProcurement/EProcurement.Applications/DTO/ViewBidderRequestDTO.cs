using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class ViewBidderRequestDTO
    {
        public string Name { get; set; }
        public DateTime DateOfEstablish { get; set; }
        public string CompanyName { get; set; }
        public int Experience { get; set; }
        public int SuccessfulTenders { get; set; }
        public string Email { get; set; }
    }
}
