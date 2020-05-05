namespace WebIVBackend.Domain.Models
{
    public class UserToRegister
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] DayIds { get; set; }

        public UserToRegister()
        {
            
        }

        public UserToRegister(string firstName, string lastName, string email, string[] dayIds)
        {
            Email = email;
            LastName = lastName;
            FirstName = firstName;
            DayIds = dayIds;
        }
    }
}