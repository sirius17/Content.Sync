using System;
using System.Linq;
using Microsoft.Practices.Unity;
using System.Collections.Generic;


namespace Content.Sync.Infrastructure.Container
{
    public class UnityDependencyContainer : IDependencyContainer
    {
        public UnityDependencyContainer(IUnityContainer unityContainer)
        {
            unityContainer.AddNewExtension<CustomContainerExtension>();
            this.InnerContainer = unityContainer;
            //_innerContainer.
        }

        public IUnityContainer InnerContainer { get; private set; }

        public IDependencyContainer Parent
        {
            get { return new UnityDependencyContainer(InnerContainer.Parent); }
        }

        public object Resolve( Type type, string name )
        {
            if (name != null)
                name = name.ToLower();
            return InnerContainer.Resolve(type, name);
        }

        public object Resolve(Type type)
        {
            return InnerContainer.Resolve(type);
        }

        public bool IsRegistered(Type type)
        {
            return InnerContainer.IsRegistered(type);
        }


        public bool IsRegistered(Type type, string name)
        {
            if (name != null)
                name = name.ToLower();
            return InnerContainer.IsRegistered(type, name);
        }


        public IDependencyContainer RegisterType(Type from, Type to, string name)
        {
            if (name != null)
                name = name.ToLower();
            InnerContainer.RegisterType(from, to, name);
            return this;
        }

        public IDependencyContainer RegisterType(Type from, Type to)
        {
            InnerContainer.RegisterType(from, to);
            return this;
        }


        public List<object> ResolveAll(Type type)
        {
            return InnerContainer.ResolveAll(type).ToList();
        }


        public IDependencyContainer RegisterInstance(Type from, object instance, string name)
        {
            if (name != null)
                name = name.ToLower();
            InnerContainer.RegisterInstance(from, name, instance);
            return this;
        }

        public IDependencyContainer RegisterInstance(Type from, object instance)
        {
            InnerContainer.RegisterInstance(from, instance);
            return this;
        }


        public object Resolve(Type type, string name, ConstructorArg[] args)
        {
            if (name != null)
                name = name.ToLower();
            if( args == null || args.Length == 0 )
                return Resolve(type, name);
            var parameterOverrides = Array.ConvertAll(args, x => new ParameterOverride(x.Name, x.Value) as ResolverOverride);
            return InnerContainer.Resolve(type, name, parameterOverrides);
        }

        public object Resolve(Type type, ConstructorArg[] args)
        {
            if (args == null || args.Length == 0)
                return Resolve(type);
            var parameterOverrides = Array.ConvertAll(args, x => new ParameterOverride(x.Name, x.Value) as ResolverOverride);
            return InnerContainer.Resolve(type, parameterOverrides);
        }
    }
}