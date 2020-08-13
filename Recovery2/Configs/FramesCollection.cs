using System.Configuration;
using Recovery2.Models;

namespace Recovery2.Configs
{
    [ConfigurationCollection(typeof(ContestItem))]
    public class FramesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new FrameElement();

        protected override object GetElementKey(ConfigurationElement element) => ((FrameElement) element).Name;

        public FrameElement this[int idx] => (FrameElement) BaseGet(idx);

        public void Clear() => BaseClear();
        public void Add(FrameElement element) => BaseAdd(element);
    }
}