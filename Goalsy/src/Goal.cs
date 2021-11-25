using System;
using System.Collections.Generic;
using Goalsy.Components;

namespace Goalsy.Objectives
{
    abstract class Goal : IObjective
    {
        private string _description;
        protected List<IComponent> _components;
        protected List<Task> _tasks;

        public string Description 
        { 
            get => _description; 
            // TO DO: Verify description is within character limit and valid
            set => _description = value; 
        }

        public void AttachComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void DetachComponent(IComponent component)
        {
            _components.Remove(component);
        }

        protected abstract void Init();
    }
}
