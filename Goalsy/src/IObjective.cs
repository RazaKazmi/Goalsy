using System.Collections.Generic;
using Goalsy.Components;

namespace Goalsy.Objectives
{
    interface IObjective
    {
        string Description { get; set; }
        void AttachComponent(IComponent component);
        void DetachComponent(IComponent component);
        IComponent GetComponentByType(ComponentType type);
        List<IComponent> GetAllComponents();
        
    }
}
