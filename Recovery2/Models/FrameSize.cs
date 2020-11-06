using System.ComponentModel;
using Recovery2.Extensions;

namespace Recovery2.Models
{
    [TypeConverter(typeof(PropertySorter))]
    public class FrameSize : NotifyPropertyChangedBase
    {
        private uint _width;
        private uint _height;
        private SizeType _type;

        public FrameSize()
        {
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != nameof(Type))
                {
                    return;
                }

                Width = _width;
                Height = _height;
            };
        }

        [DisplayName("Ширина")]
        [Description("Ширина кадра")]
        [PropertyOrder(2)]
        public uint Width
        {
            get => _width;
            set => SetProperty(ref _width, _width = Type == SizeType.Percent && value > 100 ? 100 : value);
        }

        [DisplayName("Высота")]
        [Description("Высота кадра")]
        [PropertyOrder(3)]
        public uint Height
        {
            get => _height;
            set => SetProperty(ref _height, _height = Type == SizeType.Percent && value > 100 ? 100 : value);
        }

        [DisplayName("Единица измерения")]
        [Description("Единица измерения")]
        [PropertyOrder(1)]
        public SizeType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        [TypeConverter(typeof(EnumTypeConverter))]
        public enum SizeType
        {
            [Description("Пиксель")] Pixel,
            [Description("Процент")] Percent
        }

        public override string ToString() => $"{_type.GetDescription()}, {_width}, {_height}";
    }
}