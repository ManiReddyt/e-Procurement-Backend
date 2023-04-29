using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class BuyerRegisterRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
