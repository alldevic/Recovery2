using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Recovery2.Models
{
    public class ContestItem : NotifyPropertyChangedBase
    {
        private Color _color;
        private uint _delay;
        private Keys _key;
        private string _name;

        [Description("Внутреннее имя")]
        [DisplayName("Внутреннее имя")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [Description("Цвет кадра")]
        [DisplayName("Цвет кадра")]
        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        [Description("Время показа данного кадра")]
        [DisplayName("Время показа")]
        public uint Delay
        {
            get => _delay;
            set => SetProperty(ref _delay, value);
        }

        [Description(
            "Клавиша, которую необходимо нажать для успешного прохождния. None - успешное прохождение без нажатия")]
        [DisplayName("Клавиша")]
        public Keys Key
        {
            get => _key;
            set => SetProperty(ref _key, value);
        }

        public override string ToString() => $"{_name}, {_color}, {_delay}, {_key}";
    }
}