namespace Recovery2.Models
{
    public class User
    {
        public User(string firstName, string secondName, string lastName, uint age, Gender gender)
        {
            Gender = gender;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Age = age;
        }

        public User()
        {
        }

        public string FirstName { get; private set; } = string.Empty;
        public string SecondName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public uint Age { get; private set; } = 0;
        public Gender Gender { get; private set; } = Gender.Male;
        
    }
}