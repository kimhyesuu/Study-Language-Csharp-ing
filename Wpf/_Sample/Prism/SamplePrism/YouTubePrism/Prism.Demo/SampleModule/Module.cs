using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace SampleModule
{
    class Module : IModule
    {
      private IRegionManager _regionManager;

      public Module(IRegionManager regionManager)
      {
         this._regionManager = regionManager;
      }

      public OnInitialized()
      {

      }
   }
}
