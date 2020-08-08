using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Recovery2.Extensions
{
    public static class Utils
    {
        public static void AddRadioCheckedBinding<T>(RadioButton radio, object dataSource, string dataMember,
            T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true,
                DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) =>
            {
                if ((bool) a.Value)
                {
                    a.Value = trueValue;
                }
            };
            binding.Format += (s, a) => a.Value = ((T) a.Value).Equals(trueValue);
            radio.DataBindings.Add(binding);
        }

        public static string GetDescription(this Enum enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($@"{nameof(enumerationValue)} must be of Enum type",
                    nameof(enumerationValue));
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo.Length <= 0)
            {
                return enumerationValue.ToString();
            }

            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0 
                ? ((DescriptionAttribute) attrs[0]).Description 
                : enumerationValue.ToString();
        }
    }
}