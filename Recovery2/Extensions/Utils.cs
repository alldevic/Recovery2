using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
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

        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        [DllImport("shell32.dll")]
        private static extern IntPtr ExtractIcon(IntPtr hInst, string file, int nIconIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static bool SetIcon(object form, int iIconIndex, string dllOrExe = null)
        {
            if (dllOrExe == null)
                dllOrExe = System.Reflection.Assembly.GetExecutingAssembly().Location;

            var hIcon = ExtractIcon(IntPtr.Zero, dllOrExe, iIconIndex);

            if (hIcon == IntPtr.Zero)
                return false;

            var icon = (Icon) Icon.FromHandle(hIcon).Clone();
            DestroyIcon(hIcon);

            form.GetType().GetProperty("Icon")?.SetValue(form, icon);
            return true;
        }


        public static void ScaleFont(Control control, float maxSize = 0, float shift = 0, float minSize = 13)
        {
            SizeF extent = TextRenderer.MeasureText(control.Text, control.Font);

            var hRatio = control.Height / extent.Height;
            var wRatio = control.Width / extent.Width;
            var ratio = (hRatio < wRatio) ? hRatio : wRatio;

            var newSize = control.Font.Size * ratio - 1;

            if (maxSize != 0)
            {
                newSize = Math.Min(maxSize, newSize);
            }

            newSize = (newSize - shift >= minSize) ? newSize + shift : minSize;

            control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
        }
    }
}