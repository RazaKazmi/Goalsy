using System;
using System.Collections.Generic;
using Goalsy.Components;
using Serilog;

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
            Log.Information("Component {ComponentName} added to Goal {GoalName}", component.Name, _description);
        }

        public void DetachComponent(IComponent component)
        {
            _components.Remove(component);
            Log.Information("Component {ComponentName} removed from Goal {GoalName}", component.Name, _description);
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
            Log.Information("Task added to Goal: {GoalName}", _description);
        }

        public void RemoveTask(Task task)
        {
            _tasks.Remove(task);
            Log.Information("Task removed from Goal: {GoalName}", _description);
        }

        public void RemoveAllTasks()
        {
            _tasks.Clear();
            Log.Debug("All tasks removed from Goal: {GoalName}", _description);
        }

        public List<Task> GetAllTasks()
        {
            return _tasks;
        }

        public IComponent GetComponentByType(ComponentType componentType)
        {
            foreach (IComponent component in _components)
            {
                if (component.GetComponentType() == componentType)
                {
                    Log.Debug("Component {ComponentType} found on Objective: {ObjectiveName}", componentType, _description);
                    return component;
                }
            }
            Log.Debug("Component {ComponentType} not found on Objective: {ObjectiveName}", componentType, _description);
            return null;
        }
        public List<IComponent> GetAllComponents()
        {
            return _components;
        }

        protected abstract void Init();
    }
}
