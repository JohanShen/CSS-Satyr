
namespace CSSSatyr.MyControls
{

    using System;
    using System.ComponentModel;
    using System.Reflection;

    public delegate void PropertyChanged(object Value);

    public class PropertyStub : PropertyDescriptor
    {
        private PropertyInfo info;

        public PropertyStub(PropertyInfo propertyInfo, Attribute[] attrs) : base(propertyInfo.Name, attrs)
        {
            this.info = propertyInfo;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            try
            {
                return this.info.GetValue(component, null);
            }
            catch
            {
                return null;
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            this.info.SetValue(component, value, null);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get
            {
                return this.info.ReflectedType;
            }
        }

        public override string Description
        {
            get
            {
                if (this.info != null)
                {
                    PropertyAttibute customAttribute = (PropertyAttibute)Attribute.GetCustomAttribute(this.info, typeof(PropertyAttibute));
                    if (customAttribute != null)
                    {
                        return customAttribute.PropertyDescription;
                    }
                    return base.Description;
                }
                return "";
            }
        }

        public override string DisplayName
        {
            get
            {
                if (this.info != null)
                {
                    PropertyAttibute customAttribute = (PropertyAttibute)Attribute.GetCustomAttribute(this.info, typeof(PropertyAttibute));
                    if (customAttribute != null)
                    {
                        return customAttribute.PropertyName;
                    }
                    return this.info.Name;
                }
                return "";
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return !this.info.CanWrite;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.info.PropertyType;
            }
        }
    }
}
