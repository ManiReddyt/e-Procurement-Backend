using EProcurement.Applications.DTO;
using EProcurment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EProcurement.Controllers
{
    [ApiController]
    [Route("api/buyer")]
    public class BuyerController : Controller
    {
        private IBuyerServices buyerServices;
        public BuyerController(IBuyerServices buyerServices)
        {
            this.buyerServices = buyerServices;
        }

        [HttpGet]
        [Route("Tenders")]
        public IActionResult GetTenders()
        {
            List<GetTendersDTO> tenders = this.buyerServices.GetTenders();
            return Ok(tenders);
        }

        [HttpGet]
        [Route("{id:Guid}/tender")]
        public IActionResult GetTenderById([FromRoute]Guid id)
        {
            this.buyerServices.GetTenderById(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id:Guid}/tenderdetails")]
        public IActionResult GetTenderDetails([FromRoute] Guid id)
        {
            this.buyerServices.GetTenderDetails(id);
            return Ok();
        }

        [HttpPost]
        [Route("Tender")]
        public IActionResult AddTender(TenderDTO tenderDTO)
        {
            this.buyerServices.AddTender(tenderDTO);
            return Ok();
        }

        
        [HttpPost]
        [Route("BuyerRegisterRequest")]
        public IActionResult BuyerRegisterRequest(BuyerRegisterRequestDTO registerRequest)
        {
            this.buyerServices.BuyerRegisterRequest(registerRequest);
            return Ok();
        }

        [HttpPost]
        [Route("BidderRegisterRequest")]
        public IActionResult BidderRegisterRequest(BidderRegisterRequestDTO registerRequest)
        {
            this.buyerServices.BidderRegisterRequest(registerRequest);
            return Ok();
        }


        [HttpPost]
        [Route("tender/{tenderid:Guid}/user/{userid:Guid}/approve")]
        public IActionResult ApproveTender([FromRoute]Guid tenderid, [FromRoute]Guid userid)
        {
            this.buyerServices.ApproveTender(tenderid, userid);
            return Ok();
        }

    }
}
