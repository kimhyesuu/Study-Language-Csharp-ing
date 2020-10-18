using LocalizeEnums.Resources;
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
        [LocalizedDescription("Good", typeof(EnumResources))]
        Good,
        [LocalizedDescription("Better", typeof(EnumResources))]
        Better,
        [LocalizedDescription("Best", typeof(EnumResources))]
        Best
    }
}
