using System;
using System.Collections.Generic;
using Serilog;
using Goalsy.Components;


namespace Goalsy.Objectives
{
    abstract class Task : IObjective
    {
        private string _description;
        private IObjective _parent;
        protected List<IComponent> _components;
        //protected List<Subtasks> _subtasks;

        public string Description 
        {
            get => _description;
            // TO DO: Verify description is within character limit and valid
            set => _description = value; 
        }

        public IObjective ParentObjective
        {
            // TODO: Maybe limit returning a null parent value in future
            get => _parent;
            set => _parent = value;
        }

        public void AttachComponent(IComponent component)
        {
            foreach (IComponent attachedComponent in _components)
            {
                if (attachedComponent.GetComponentType() == component.GetComponentType())
                {
                    Log.Debug("Component of this type already exists on {TaskName}", _description);
                    return;
                }
            }
            _components.Add(component);
            Log.Information("Component {ComponentName} added to Task {TaskName}", component.Name, _description);
        }

        public void DetachComponent(IComponent component)
        {
            if (_components.Contains(component))
            {
                _components.Remove(component);
                Log.Information("Component {ComponentName} removed from Task {TaskName}", component.Name, _description);
            }
            else
            {
                Log.Debug("Component {ComponentName} not found on Task {TaskName}", component.Name, _description);
                throw new InvalidOperationException("Compnent to remove not found on task");
            }
        }

        public IComponent GetComponentByType(ComponentType componentType)
        {
            foreach (IComponent component in _components)
            {
                if (component.GetComponentType() == componentType)
                {
                    return component;
                }
            }
            return null;
        }

        public List<IComponent> GetAllComponents()
        {
            return _components;
        }

        protected abstract void Init();
    }
}
