using System.ComponentModel;
using Recovery2.Extensions;

namespace Recovery2.Models
{
    
    [TypeConverter(typeof(PropertySorter))]
    public class FrameSize
    {
        private uint _width;
        private uint _height;
        private SizeType _type;

        [DisplayName("Ширина")]
        [Description("Ширина кадра")]
        [PropertyOrder(2)]
        public uint Width
        {
            get => _width;
            set => _width = value;
        }

        [DisplayName("Высота")]
        [Description("Высота кадра")]
        [PropertyOrder(3)]
        public uint Height
        {
            get => _height;
            set => _height = value;
        }

        [DisplayName("Единица измерения")]
        [Description("Единица измерения")]
        [PropertyOrder(1)]
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