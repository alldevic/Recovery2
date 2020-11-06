using System.ComponentModel;
using Recovery2.Extensions;

namespace Recovery2.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FrameSize
    {
        private int _width;
        private int _height;
        private SizeType _type;

        [DisplayName("Ширина")]
        [Description("Ширина кадра")]
        public int Width
        {
            get => _width;
            set => _width = value;
        }

        [DisplayName("Высота")]
        [Description("Высота кадра")]
        public int Height
        {
            get => _height;
            set => _height = value;
        }

        [DisplayName("Единица измерения")]
        [Description("Единица измерения")]
        public SizeType Type
        {
            get => _type;
            set => _type = value;
        }

        [TypeConverter(typeof(EnumTypeConverter))]
        public enum SizeType
        {
            [Description("Процент")]
            Percent,
            [Description("Пиксель")]
            Pixel
        }

        public override string ToString() => $"{_type.GetDescription()}, {_width}, {_height}";
    }
}