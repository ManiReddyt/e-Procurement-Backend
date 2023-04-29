namespace EProcurement.Domain.Models
{
    public class Tender
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int Budget { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid AssignedTo { get; set; }
    }
}
