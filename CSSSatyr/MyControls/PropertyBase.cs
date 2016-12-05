
namespace CSSSatyr.MyControls
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Reflection;

    public class PropertyBase : ICustomTypeDescriptor
    {
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            ArrayList list = new ArrayList();
            Type type = base.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if ((info.DeclaringType == type) || (info.PropertyType.ToString() == "System.Drawing.Color"))
                {
                    PropertyStub stub;
                    BrowsableAttribute customAttribute = (BrowsableAttribute)Attribute.GetCustomAttribute(info, typeof(BrowsableAttribute));
                    if (customAttribute != null)
                    {
                        if (customAttribute.Browsable || (info.PropertyType.ToString() == "System.Drawing.Color"))
                        {
                            stub = new PropertyStub(info, attributes);
                            list.Add(stub);
                        }
                    }
                    else
                    {
                        stub = new PropertyStub(info, attributes);
                        list.Add(stub);
                    }
                }
            }
            return new PropertyDescriptorCollection((PropertyDescriptor[])list.ToArray(typeof(PropertyDescriptor)));
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}
