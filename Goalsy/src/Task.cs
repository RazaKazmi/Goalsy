using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goalsy.Components;


namespace Goalsy.Objectives
{
    abstract class Task : IObjective
    {
        private string _description;
        protected List<IComponent> _components;
        //protected List<Subtasks> _subtasks;

        public string Description 
        {
            get => _description;
            // TO DO: Verify description is within character limit and valid
            set => throw new NotImplementedException(); 
        }

        public void AttachComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void DetachComponent(IComponent component)
        {
            _components.Remove(component);
        }
    }
}
