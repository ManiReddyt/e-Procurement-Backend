using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurement.Applications.DTO
{
    public class RecommendationsDTO
    {
        public string BidderName { set; get; }
        public int PriceQuoted { set; get; }
        public int Warrenty { set; get; }
        public int BidderExperience { set; get; }
        public double Rating { set; get; }
    }
}
