namespace backend.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        
        public string userName { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
    }
}
