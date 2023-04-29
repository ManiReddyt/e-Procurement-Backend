using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class RegisterRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
        public string DesignationORCompanyName { set; get; }
    }
}
