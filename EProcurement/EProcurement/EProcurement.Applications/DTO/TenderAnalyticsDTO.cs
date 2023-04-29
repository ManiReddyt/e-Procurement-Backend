using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class TenderAnalyticsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RecommendationsAndBidsDTO> Recommendations { get; set; }
        public List<RecommendationsAndBidsDTO> Bids { get; set; }
    }
}
