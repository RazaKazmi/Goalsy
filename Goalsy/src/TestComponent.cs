using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goalsy.Components
{
    public class TestComponent : IComponent
    {
        public string Name { get => "TestComponent" ; set => throw new NotImplementedException(); }
    }
}
