using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goalsy.Components;

namespace Goalsy.Objectives
{
    class TestGoal : Goal
    {
        public TestGoal(string name)
        {
            Init();
            Description = name;
        }

        protected override void Init()
        {
            _components = new List<IComponent>();
            _tasks = new List<Task>();
        }
    }
}
