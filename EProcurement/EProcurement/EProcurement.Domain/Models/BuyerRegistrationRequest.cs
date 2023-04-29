namespace EProcurement.Domain.Models
{
    public class BuyerRegistrationRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsApproved { set; get; }
    }
}
