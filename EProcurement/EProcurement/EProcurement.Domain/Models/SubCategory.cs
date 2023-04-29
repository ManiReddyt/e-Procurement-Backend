namespace EProcurement.Domain.Models
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
