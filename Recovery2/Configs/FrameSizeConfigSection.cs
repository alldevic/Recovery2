using System.Configuration;

namespace Recovery2.Configs
{
    public class FrameSizeConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("framesize")]
        public FrameSizeElement FrameSize
        {
            get => (FrameSizeElement) base["framesize"];
            set => base["framesize"] = value;
        }
    }
}