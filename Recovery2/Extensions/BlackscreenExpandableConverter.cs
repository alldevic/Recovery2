using System;
using System.ComponentModel;
using System.Linq;

namespace Recovery2.Extensions
{
    public class BlackscreenExpandableConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
            Attribute[] attributes)
        {
            var props = base.GetProperties(context, value, attributes)
                .OfType<PropertyDescriptor>()
                .Where(pd => !string.Equals(pd.Name, "Name"))
                .ToArray();
            return new PropertyDescriptorCollection(props);
        }
    }
}