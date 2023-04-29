using EProcurement.Applications.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurment.Services.Contracts
{
    public interface IAdminServices
    {
        public List<BuyerRegisterRequestDTO> GetBuyerRegisterRequests();
        public List<BidderRegisterRequestDTO> GetBidderRegisterRequests();
        public void AcceptBidder(Guid id);
        public void RejectBidder(Guid id);
        public void AcceptBuyer(Guid id);
        public void RejectBuyer(Guid id);
    }
}
