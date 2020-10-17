using System.ComponentModel;

namespace LocalizeEnums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Status
    {
        [Description("This is horrible")]
        Horrible,
        [Description("This is bad")]
        Bad,
        [Description("This is Soso")]
        Soso,
        Good,
        Better,
        Best
    }
}
