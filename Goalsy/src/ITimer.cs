using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goalsy.Components
{
    interface ITimer : IComponent
    {
        public void Start();
        public void Pause();
        public void Reset();
    }
}
