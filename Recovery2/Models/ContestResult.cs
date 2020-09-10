using System.Collections.Generic;

namespace Recovery2.Models
{
    public class ContestResult
    {
        private User _user;
        private GlobalConfig _config;

        public ContestResult(User user, GlobalConfig config)
        {
            _user = user;
            _config = config;
        }

        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public string SecondName => _user.SecondName;
        public uint Age => _user.Age;
        public Gender Gender => _user.Gender;

        public uint Count => _config.Count;

        public List<ContestResultItem> Results { get; set; }
    }
}