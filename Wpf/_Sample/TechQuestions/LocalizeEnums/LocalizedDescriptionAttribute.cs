namespace LocalizeEnums
{
    using LocalizeEnums.Resources;
    using System;
    using System.ComponentModel;
    using System.Resources;

    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        //스레드가 읽어주나?

        ResourceManager _resourceManager;
        private readonly string _resourceKey;

        public LocalizedDescriptionAttribute(string resourcekey, Type resourceType)
        {
            _resourceManager = new ResourceManager(typeof(EnumResources));
            this._resourceKey = resourcekey;
        }

        public override string Description
        {
            get
            {
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description) ? $"[[{_resourceKey}]]" : description;
            }
        }
    }
}
