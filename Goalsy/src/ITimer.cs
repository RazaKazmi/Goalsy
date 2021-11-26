using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goalsy.Components
{
    interface ITimer : IComponent
    {
        // Start or resume the timer
        public void Start();
        // Pause the timer
        public void Pause();
        // Reset timer back to intial values entered.
        public void Reset();
    }
}
