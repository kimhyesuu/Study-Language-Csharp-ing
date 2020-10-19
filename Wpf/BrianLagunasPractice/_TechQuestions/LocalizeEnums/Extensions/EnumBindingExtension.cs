using System;
using System.Windows.Markup;

namespace LocalizeEnums.Extensions
{
    public class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingExtension(Type enumType)
        {  
            if (enumType is null || !enumType.IsEnum) throw new NullReferenceException
                    ($"{nameof(enumType)} must be of type Enums and must not be null");


            //Status(enum) 타입을 아예 다 가져오는 거구나 
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Retrieves an array of the values of the constants in a specified enumeration.
            return Enum.GetValues(EnumType);
        }
    }
}
