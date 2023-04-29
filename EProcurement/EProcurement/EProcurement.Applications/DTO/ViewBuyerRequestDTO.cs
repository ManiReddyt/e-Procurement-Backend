using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class ViewBuyerRequestDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
