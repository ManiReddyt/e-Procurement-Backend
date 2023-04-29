using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class TenderDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int Budget { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
