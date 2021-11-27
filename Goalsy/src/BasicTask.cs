using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goalsy.Objectives;
using Goalsy.Components;

namespace Goalsy.Objectives
{
    class BasicTask : Task
    {
        BasicTask()
        {
            Init();
        }

        protected override void Init()
        {
            _components = new List<IComponent>();
        }
    }
}
