using System.ComponentModel;
using System.Runtime.CompilerServices;
using Recovery2.Annotations;

namespace Recovery2.Models
{
    public class User : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _secondName = string.Empty;
        private string _lastName = string.Empty;
        private uint _age = 0;
        private Gender _gender = Gender.Male;

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


        public void Clear()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Gender = Gender.Male;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                if (value == _secondName) return;
                _secondName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public uint Age
        {
            get => _age;
            set
            {
                var parsedValue = uint.Parse(value.ToString());
                if (parsedValue == _age) return;
                _age = parsedValue;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                if (value == _gender) return;
                _gender = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}