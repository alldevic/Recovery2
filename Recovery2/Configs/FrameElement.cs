using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Recovery2.Configs
{
    public class FrameElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get => (string) base["name"];
            set => base["name"] = string.IsNullOrEmpty(value) ? Guid.NewGuid().ToString() : value;
        }

        [ConfigurationProperty("color", DefaultValue = "0xFFFFFFFF", IsKey = false, IsRequired = true)]
        public Color Color
        {
            get => (Color) base["color"];
            set => base["color"] = value;
        }

        [ConfigurationProperty("delay", DefaultValue = "1000", IsKey = false, IsRequired = true)]
        public uint Delay
        {
            get => (uint) base["delay"];
            set => base["delay"] = value;
        }

        [ConfigurationProperty("key", DefaultValue = "None", IsKey = false, IsRequired = true)]
        public Keys Key
        {
            get => (Keys) base["key"];
            set => base["key"] = value;
        }
    }
}