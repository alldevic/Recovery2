using System.Configuration;
using Recovery2.Models;

namespace Recovery2.Configs
{
    public class FrameSizeElement : ConfigurationElement
    {
        [ConfigurationProperty("width", DefaultValue = "300", IsKey = false, IsRequired = true)]
        public int Width
        {
            get => (int) base["width"];
            set => base["width"] = value;
        }
        
        [ConfigurationProperty("height", DefaultValue = "150", IsKey = false, IsRequired = true)]
        public int Height
        {
            get => (int) base["height"];
            set => base["height"] = value;
        }

        [ConfigurationProperty("type", DefaultValue = "Pixel", IsKey = false, IsRequired = true)]
        public FrameSize.SizeType Type
        {
            get => (FrameSize.SizeType) base["type"];
            set => base["type"] = value;
        }
    }
}