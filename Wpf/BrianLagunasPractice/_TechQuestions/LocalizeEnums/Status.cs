using LocalizeEnums.Resources;
using System.ComponentModel;

namespace LocalizeEnums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Status
    {
        [Description("010")]
        Horrible,
        [Description("011")]
        Bad,
        [Description("017")]
        Soso,
        //[LocalizedDescription("Good", typeof(EnumResources))]
        //Good,
        //[LocalizedDescription("Better", typeof(EnumResources))]
        //Better,
        //[LocalizedDescription("Best", typeof(EnumResources))]
        //Best
    }
}
