using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Recovery2.Extensions;

namespace Recovery2.Models
{
    public class ContestItem : NotifyPropertyChangedBase
    {
        private Color _color;
        private uint _delay;
        private Keys _key;
        private string _name;
        private ContentItemType _type;
        private string _imagePath;

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
            "Клавиша, которую необходимо нажать для успешного прохождения. None - успешное прохождение без нажатия")]
        [DisplayName("Клавиша")]
        [Editor(typeof(CustomShortcutKeysEditor), typeof(UITypeEditor))]
        public Keys Key
        {
            get => _key;
            set => SetProperty(ref _key, value);
        }
        
        [DisplayName("Тип кадра")]
        [Description("Выберите тип содержимого для кадра: сплошной цвет, текст, изображение")]
        [TypeConverter(typeof(EnumTypeConverter))]
        public ContentItemType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }


        [DisplayName("Путь до файла")]
        [Description("Путь до изображения для кадра (если выбран тип \"Изображение\"")]
        [Editor(typeof(ImageFileEditor), typeof(UITypeEditor))]
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public override string ToString() => $"{_name}, {_color}, {_delay}, {_key}";
    }
}