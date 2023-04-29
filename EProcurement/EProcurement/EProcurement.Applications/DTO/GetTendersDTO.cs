using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class GetTendersDTO
    {
        public Guid TenderId { get; set; }
        public string Title { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
