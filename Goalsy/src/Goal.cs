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
            foreach (IComponent attachedComponent in _components)
            {
                if (attachedComponent.GetComponentType() == component.GetComponentType())
                {
                    Log.Debug("Component of this type already exists on {GoalName}", _description);
                    return;
                }
            }
            _components.Add(component);
            Log.Information("Component: {ComponentName} added to Goal: {GoalName}", component.Name, _description);
        }

        public void DetachComponent(IComponent component)
        {
            if (component.GetComponentType() == ComponentType.Timer)
                return;
            if (_components.Contains(component))
            {
                _components.Remove(component);
                Log.Information("Component: {ComponentName} removed from Goal: {GoalName}", component.Name, _description);
            }
            else
            {
                Log.Debug("Component: {ComponentName} not found on Goal: {GoalName}", component.Name, _description);
                throw new InvalidOperationException("Compnent to remove not found on goal");
            }
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
            task.ParentObjective = this;
            Log.Information("Task: {TaskName} added to Goal: {GoalName}", task.Description, this._description);
        }

        public void RemoveTask(Task task)
        {
            if (_tasks.Contains(task))
            {
                _tasks.Remove(task);
                // Note: tasks parent objective wont need to be set
                // unless the task is being moved to a different goal
                // or not deleted outright
                task.ParentObjective = null;
                Log.Information("Task removed from Goal: {GoalName}", _description);
            }
            else
            {
                throw new InvalidOperationException("Task to remove does not exist under goal");
            }
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
                    Log.Debug("Component: {ComponentType} found on Objective: {ObjectiveName}", componentType, _description);
                    return component;
                }
            }
            Log.Debug("Component: {ComponentType} not found on Objective: {ObjectiveName}", componentType, _description);
            throw new InvalidOperationException("Component type not found on goal");
            //return null;
        }
        public List<IComponent> GetAllComponents()
        {
            return _components;
        }

        protected abstract void Init();
    }
}
