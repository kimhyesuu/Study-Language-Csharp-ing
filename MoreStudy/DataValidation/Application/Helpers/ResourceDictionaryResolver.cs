namespace Application.Helpers
{
    using System;
    using System.Windows;

    public static class ResourceDictionaryResolver
    {
        public static ResourceDictionary GetResourceDictionary(string uri)
        {
            ResourceDictionary resourceDictionary = null;
            foreach (ResourceDictionary resourceDictionaryScan in Application.Current.Resources.MergedDictionaries)
            {
                if (resourceDictionaryScan.Source == new Uri(uri, UriKind.RelativeOrAbsolute))
                {
                    resourceDictionary = resourceDictionaryScan;
                    break;
                }
            }

            return resourceDictionary;
        }
    }
}