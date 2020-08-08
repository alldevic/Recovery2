using System;

namespace Recovery2.Models
{
    public class User
    {
        public User(string firstName, string secondtName, string lasttName, uint age, Gender gemder)
        {
            Gemder = gemder;
            FirstName = firstName;
            SecondtName = secondtName;
            LasttName = lasttName;
            Age = age;
        }

        public User()
        {
        }

        public string FirstName { get; private set; } = string.Empty;
        public string SecondtName { get; private set; } = string.Empty;
        public string LasttName { get; private set; } = string.Empty;
        public uint Age { get; private set; } = 0;
        public Gender Gemder { get; private set; } = Gender.Male;
        
    }
}