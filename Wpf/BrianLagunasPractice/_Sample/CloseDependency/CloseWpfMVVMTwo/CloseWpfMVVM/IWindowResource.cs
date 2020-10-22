using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseWpfMVVM
{
    //window로 묵고
    interface IWindowResource
    {
        Action Close { get; set; }
        bool CanClose();
    }
}
