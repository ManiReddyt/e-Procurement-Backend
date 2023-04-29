using EProcurement.Applications.DTO;
using EProcurment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EProcurement.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private IAdminServices adminServices;
        public AdminController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        [HttpGet]
        [Route("buyerregisterrequests")]
        public IActionResult BuyerRequests()
        {
            List<BuyerRegisterRequestDTO> requests = this.adminServices.GetBuyerRegisterRequests();
            return Ok(requests);
        }


        [HttpGet]
        [Route("bidderregisterrequests")]
        public IActionResult BidderRequests()
        {
            List<BidderRegisterRequestDTO> requests = this.adminServices.GetBidderRegisterRequests();
            return Ok(requests);
        }

        [HttpPut]
        [Route("{id:Guid}/acceptbidder")]
        public IActionResult AcceptBidder([FromRoute]Guid id)
        {
            this.adminServices.AcceptBidder(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}/rejectbidder")]
        public IActionResult RejecttBidder([FromRoute] Guid id)
        {
            this.adminServices.RejectBidder(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}/acceptbuyer")]
        public IActionResult AcceptBuyerr([FromRoute] Guid id)
        {
            this.adminServices.AcceptBuyer(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}/rejectbuyer")]
        public IActionResult RejecttBuyer([FromRoute] Guid id)
        {
            this.adminServices.RejectBuyer(id);
            return Ok();
        }
    }
}
