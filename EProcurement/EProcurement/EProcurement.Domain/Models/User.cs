namespace EProcurement.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public int Experience { get; set; }
    }
}
