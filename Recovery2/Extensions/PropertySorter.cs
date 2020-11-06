using System;
using System.Collections;
using System.ComponentModel;
using static System.String;

namespace Recovery2.Extensions
{
    public class PropertySorter : ExpandableObjectConverter
    {
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
            Attribute[] attributes)
        {
            var pdc = TypeDescriptor.GetProperties(value, attributes);
            var orderedProperties = new ArrayList();

            foreach (PropertyDescriptor pd in pdc)
            {
                var attribute = pd.Attributes[typeof(PropertyOrderAttribute)];

                if (attribute != null)
                {
                    var poa = (PropertyOrderAttribute) attribute;
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
                }
                else
                {
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
                }
            }

            orderedProperties.Sort();


            var propertyNames = new ArrayList();

            foreach (PropertyOrderPair pop in orderedProperties)
                propertyNames.Add(pop.Name);


            return pdc.Sort((string[]) propertyNames.ToArray(typeof(string)));
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        public PropertyOrderAttribute(int order)
        {
            Order = order;
        }
        public int Order { get; }
    }

    public class PropertyOrderPair : IComparable
    {
        private readonly int _order;

        public string Name { get; }

        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            Name = name;
        }


        public int CompareTo(object obj)
        {
            var otherOrder = ((PropertyOrderPair) obj)._order;

            if (otherOrder == _order)
            {
                var otherName = ((PropertyOrderPair) obj).Name;
                return CompareOrdinal(Name, otherName);
            }

            if (otherOrder > _order)
            {
                return -1;
            }

            return 1;
        }
    }
}