using System;
using CSSSatyr.Extends;
namespace CSSSatyr.MyControls
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyAttibute : Attribute
    {
        private object _DefaultValue;
        private string _PropertyDescription;
        private string _PropertyName;

        public PropertyAttibute(string _propertyName = "", string _propertyDescription = "", object _DefalutValue = default(object))
        {
            this._PropertyName = CommonLib.GetLocalString(_propertyName);
            this._PropertyDescription = CommonLib.GetLocalString(_propertyDescription);
            this._DefaultValue = _DefalutValue;
        }

        public object DefaultValue
        {
            get
            {
                return this._DefaultValue;
            }
        }

        public string PropertyDescription
        {
            get
            {
                return this._PropertyDescription;
            }
        }

        public string PropertyName
        {
            get
            {
                return this._PropertyName;
            }
        }
    }
}
