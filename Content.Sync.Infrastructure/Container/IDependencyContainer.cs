using System;
using System.Collections.Generic;

namespace Content.Sync.Infrastructure
{
    public interface IDependencyContainer
    {
        IDependencyContainer Parent { get; }
        bool IsRegistered(Type type);
        bool IsRegistered(Type type, string name);
        IDependencyContainer RegisterType(Type from, Type to, string name);
        IDependencyContainer RegisterType(Type from, Type to);
        object Resolve(Type type, string name, ConstructorArg[] args );
        object Resolve(Type type, ConstructorArg[] args);
        object Resolve(Type type, string name);
        object Resolve(Type type);
        List<object> ResolveAll(Type type);
        IDependencyContainer RegisterInstance(Type from, object instance, string name);
        IDependencyContainer RegisterInstance(Type from, object instance);
        
    }


    public class ConstructorArg
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}