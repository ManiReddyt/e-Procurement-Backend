namespace EProcurement.Domain.Models
{
    public class Prediction
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public Guid BidId { get; set; }
    }
}
