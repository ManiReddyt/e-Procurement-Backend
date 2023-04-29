namespace EProcurement.Domain.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int QuotingPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeliveryOn { get; set; }
        public int Warrenty { get; set; }
        public string WarremtyTerms { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public Guid TenderId { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
