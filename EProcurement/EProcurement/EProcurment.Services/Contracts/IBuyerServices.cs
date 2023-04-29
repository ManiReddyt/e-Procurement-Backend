using EProcurement.Applications.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurment.Services.Contracts
{
    public interface IBuyerServices
    {
        public void BuyerRegisterRequest(BuyerRegisterRequestDTO registerRequest);
        public void BidderRegisterRequest(BidderRegisterRequestDTO registerRequest);
        public void AddTender(TenderDTO tenderDTO);
        public List<GetTendersDTO> GetTenders();
        public TenderAnalyticsDTO GetTenderById(Guid id);
        public TenderDTO GetTenderDetails(Guid id);
        public void ApproveTender(Guid tenderId, Guid userId);
    }
}
