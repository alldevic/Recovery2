using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

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

        [Name(@"Фамилия"), Index(1)] public string LastName => _user.LastName;
        [Name(@"Имя"), Index(2)] public string FirstName => _user.FirstName;
        [Name(@"Отчество"), Index(3)] public string SecondName => _user.SecondName;
        [Name(@"Возраст"), Index(4)] public uint Age => _user.Age;
        [Name(@"Пол"), Index(5)] public Gender Gender => _user.Gender;
        [Name(@"Всего"), Index(6)] public int Count => Results.Count;
        [Name(@"Правильно"), Index(7)] public int PositiveCount => Results.Count(x => x.Success);
        [Name(@"Неправильно"), Index(8)] public int NegativeCount => Results.Count(x => !x.Success);

        [Ignore]
        public List<ContestResultItem> Results { get; set; }
    }
}