using System;
using System.Collections.Generic;

namespace Goalsy.Components
{
    internal class Priority : IComponent
    {
        public string Name => "PriorityComponent";

        public ComponentType GetComponentType()
        {
            return ComponentType.Priority;
        }
    }
}
