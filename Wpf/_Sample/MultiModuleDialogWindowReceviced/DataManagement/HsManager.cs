using EventAggregator.Core;
using System.Collections.Generic;

namespace DataManagement
{
    public class HsManager<T> : IHsManager<T>
    {
        public HsRepository<T> HsRepository;

        public HsManager()
        {
            HsRepository = new HsRepository<T>();
        }

        public bool Add(T parameter)
        {
            var para = parameter;
            if (parameter != null)
            {
                HsRepository.Add(parameter);
                return true;
            }
            return false;
        }

        public List<T> GetString { get => HsRepository<T>.Patients; }

    }
}
