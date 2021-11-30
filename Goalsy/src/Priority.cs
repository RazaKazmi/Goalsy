using System;
using System.Collections.Generic;

namespace Goalsy.Components
{
    internal class Priority : IComponent
    {
        public enum PriorityLevel
        {
            Low = 1,
            Medium,
            High,
            Critical
        }

        public string Name => "PriorityComponent";
        private PriorityLevel _priorityLevel;

        PriorityLevel Level
        {
            get { return _priorityLevel; }
            set { _priorityLevel = value; }
        }

        public Priority(PriorityLevel priorityLevel)
        {
            _priorityLevel = priorityLevel;
        }

        public ComponentType GetComponentType()
        {
            return ComponentType.Priority;
        }
    }
}
