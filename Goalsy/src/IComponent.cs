
namespace Goalsy.Components
{
    enum ComponentType
    {
        Timer,
        Priority
    }

    interface IComponent
    {
        string Name { get; }
        ComponentType GetComponentType();
    }
}
