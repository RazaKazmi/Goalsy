using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goalsy.Components;

namespace Goalsy.Objectives
{
    internal class TimedGoal : Goal
    {
        private const int DefaultHours = 0;
        private const int DefaultMinutes = 10;
        private const int DefaultSeconds = 0;

        public TimedGoal(string name)
        {
            Init();
            Description = name;
        }

        protected override void Init()
        {
            _components = new List<IComponent>();
            _tasks = new List<Task>();
            this.AttachComponent(new CountdownTimer(DefaultHours,DefaultMinutes,DefaultSeconds));
        }
    }
}
