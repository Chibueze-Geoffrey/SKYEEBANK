using SKYEEBANK.Common;


namespace SKYEEBANK.Entities
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName, string emailAdress, string password, string pin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAdress;
            Password = password;
            Created = DateTime.Now;
            Pin = pin;

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public EntityAffirmation entityAffirmation { get; set; }
        public string Pin { get; set; }

    }
}
