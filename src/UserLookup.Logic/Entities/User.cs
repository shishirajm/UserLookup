namespace UserLookup.Domain.Common
{
    public class User : Entity
    {
        public User(long id, string firstName, string lastName, int age, char gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public override long Id { get; protected set; }

        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public int Age { get;  set; }

        public char Gender { get;  set; }
    }
}
