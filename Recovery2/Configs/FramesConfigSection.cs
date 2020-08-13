using System.Configuration;

namespace Recovery2.Configs
{
    public class FramesConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("frames")] public FramesCollection FrameItems
        {
            get => (FramesCollection) base["frames"];
            set => base["frames"] = value;
        }
    }
}