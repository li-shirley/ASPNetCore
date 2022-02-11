namespace ViewModelFun.Models
{
    public class User
    {
        public string FirstName; 
        public string LastName;

        public User(string firstName, string lastName = " ")
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}