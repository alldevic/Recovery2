using System.ComponentModel;

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

        public enum SizeType
        {
            [Description("Соотношение")]
            Ratio,
            [Description("Абсолютное")]
            Pixel
        }

        public override string ToString() => $"{_type}, {_width}, {_height}";
    }
}