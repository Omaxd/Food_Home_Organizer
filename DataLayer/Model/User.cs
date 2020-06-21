namespace DataLayer.Model
{
    public class User : BaseEntity
    {
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Cart Cart { get; set; }
    }
}
