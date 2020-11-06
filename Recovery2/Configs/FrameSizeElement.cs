using System.Configuration;
using Recovery2.Models;

namespace Recovery2.Configs
{
    public class FrameSizeElement : ConfigurationElement
    {
        [ConfigurationProperty("width", DefaultValue = "300", IsKey = false, IsRequired = true)]
        public uint Width
        {
            get => (uint) base["width"];
            set => base["width"] = Type == FrameSize.SizeType.Percent && value > 100 ? 100 : value;
        }

        [ConfigurationProperty("height", DefaultValue = "150", IsKey = false, IsRequired = true)]
        public uint Height
        {
            get => (uint) base["height"];
            set => base["height"] = Type == FrameSize.SizeType.Percent && value > 100 ? 100 : value;
        }

        [ConfigurationProperty("type", DefaultValue = "Pixel", IsKey = false, IsRequired = true)]
        public FrameSize.SizeType Type
        {
            get => (FrameSize.SizeType) base["type"];
            set => base["type"] = value;
        }
    }
}