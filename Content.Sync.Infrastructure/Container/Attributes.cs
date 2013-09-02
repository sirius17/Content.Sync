using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Content.Sync.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class DependencyAttribute : Attribute
    {
        public DependencyAttribute() : this(null) { }

        public DependencyAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Constructor)]
    public class InjectionConstructorAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InjectionMethodAttribute : Attribute
    {
    }
}
