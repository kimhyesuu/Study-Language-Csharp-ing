using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventAggregator.Core
{
    public interface IHsManager<T>
    {
        bool Add(T parameter);
        List<T> GetString { get; }
    }
}