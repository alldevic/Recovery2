using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Recovery2.Models
{
    public class ContestResult
    {
        private User _user;

        public ContestResult(User user)
        {
            _user = user;
        }

        [Name(@"Дата"), Index(1)] public DateTime Created { get; set; }
        [Name(@"Фамилия"), Index(2)] public string LastName => _user.LastName;
        [Name(@"Имя"), Index(3)] public string FirstName => _user.FirstName;
        [Name(@"Отчество"), Index(4)] public string SecondName => _user.SecondName;
        [Name(@"Возраст"), Index(5)] public uint Age => _user.Age;
        [Name(@"Пол"), Index(6)] public Gender Gender => _user.Gender;
        [Name(@"Всего"), Index(7)] public int Count => Results.Count;
        [Name(@"Правильно"), Index(8)] public int PositiveCount => Results.Count(x => x.Success);
        [Name(@"Неправильно"), Index(9)] public int NegativeCount => Results.Count(x => !x.Success);

        [Name(@"% Правильно"), Index(10)]
        public string ProcPositiveCount =>
            Count == 0 || PositiveCount == 0 ? "0" : ((decimal) PositiveCount / Count * 100M).ToString("0.00");

        [Name(@"% Неправильно"), Index(11)]
        public string ProcNegativeCount =>
            Count == 0 || NegativeCount == 0 ? "0" : ((decimal) NegativeCount / Count * 100M).ToString("0.00");

        [Name(@"Ср. время на правильный"), Index(12)]
        public int TimmPosCount => Count == 0 || PositiveCount == 0
            ? 0
            : (int) Results.Where(x => x.Success)
                .Average(x => x.Elapsed);

        [Name(@"Ср. время на неправильный"), Index(13)]
        public int TimeNegCount => Count == 0 || NegativeCount == 0
            ? 0
            : (int) Results.Where(x => !x.Success)
                .Average(x => x.Elapsed);

        [Name(@"Ср. время на правильный после неправильного"), Index(14)]
        public int TimmPosNegCount
        {
            get
            {
                if (Count == 0 || NegativeCount == 0 || PositiveCount == 0)
                    return 0;

                var res = Results.ToList().Where(x =>
                    Results.IndexOf(x) != 0 && x.Success && !Results[Results.IndexOf(x) - 1].Success).ToList();

                if (!res.Any())
                {
                    return 0;
                }
                return (int) res.Average(x => x.Elapsed);
            }
        }

        [Ignore] public List<ContestResultItem> Results { get; set; }
    }
}