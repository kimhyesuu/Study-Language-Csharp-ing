using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeEnums
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type)
            : base(type)
        {

        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == typeof(string))
            {
                if(value != null)
                {
                    //using System.Reflection;
                    FieldInfo info = value.GetType().GetField(value.ToString());
                    if(info != null)
                    {
                        var attributes = 
                            (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

                        //attributes의 길이가 0보다 길고 공백 혹은 널이 아니면 attributes[0].Description
                        // 그외 value.ToString()
                        return (attributes.Length > 0 && !string.IsNullOrWhiteSpace(attributes[0].Description)
                            ? attributes[0].Description : value.ToString());
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
