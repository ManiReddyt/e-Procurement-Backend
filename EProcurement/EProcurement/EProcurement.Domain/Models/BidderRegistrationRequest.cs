namespace EProcurement.Domain.Models
{
    public class BidderRegistrationRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int Experience { get; set; } 
        public int SuccessfulTenders { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsApproved { set; get; }
    }
}
