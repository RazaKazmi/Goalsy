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
        public BasicTask(string description)
        {
            Description = description;
            Init();
        }

        protected override void Init()
        {
            _components = new List<IComponent>();
        }
    }
}
