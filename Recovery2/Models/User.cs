namespace Recovery2.Models
{
    public class User : NotifyPropertyChangedBase
    {
        private string _firstName = string.Empty;
        private string _secondName = string.Empty;
        private string _lastName = string.Empty;
        private uint _age;
        private Gender _gender = Gender.Male;

        public void Clear()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Gender = Gender.Male;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(SecondName) || string.IsNullOrWhiteSpace(SecondName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }

            return Age != 0;
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string SecondName
        {
            get => _secondName;
            set => SetProperty(ref _secondName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public uint Age
        {
            get => _age;
            set => SetProperty(ref _age, uint.Parse(value.ToString()));
        }

        public Gender Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }
    }
}