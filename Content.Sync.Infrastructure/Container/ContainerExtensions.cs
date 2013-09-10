using System.Reflection;
using System;

namespace Content.Sync.Infrastructure
{
    public static class ContainerExtensions
    {
        public static T Resolve<T>(this IDependencyContainer container, string name)
        {
            return (T)(container.Resolve(typeof(T), name));
        }

        public static T Resolve<T>(this IDependencyContainer container)
        {
            return (T)(container.Resolve(typeof(T)));
        }

        public static T Resolve<T>(this IDependencyContainer container, object args)
        {
            return (T)container.Resolve(typeof(T), null, args);
        }

        public static T Resolve<T>( this IDependencyContainer container, string name, object args )
        {
            return (T)container.Resolve(typeof (T), name, args) ;
        }

        public static object Resolve(this IDependencyContainer container, Type type, object args)
        {
            return container.Resolve(type, null, args);
        }

        public static object Resolve(this IDependencyContainer container, Type type, string name, object args)
        {
            var dyn = args.GetType();
            var properties = dyn.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var parameters = Array.ConvertAll(properties, p =>
                                             {
                                                 var value = p.GetValue(args, null);
                                                 return new ConstructorArg() {Name = p.Name, Value = value};
                                             });
            return container.Resolve(type, name, parameters);
        }

        public static IDependencyContainer RegisterType<TFrom, TTo>(this IDependencyContainer container, string name)
            where TTo : TFrom
        {
            container.RegisterType(typeof (TFrom), typeof (TTo), name);
            return container;
        }

        public static IDependencyContainer RegisterType<TFrom, TTo>(this IDependencyContainer container)
            where TTo : TFrom
        {
            container.RegisterType(typeof(TFrom), typeof(TTo));
            return container;
        }

        public static bool IsRegistered<T>(this IDependencyContainer container)
        {
            return container.IsRegistered(typeof (T));
        }

        public static bool IsRegistered<T>(this IDependencyContainer container, string name)
        {
            return container.IsRegistered(typeof(T), name);
        }

        public static  IDependencyContainer RegisterInstance<T>( this IDependencyContainer container, T instance, string name )
        {
            return container.RegisterInstance(typeof (T), instance, name);
        }

        public static IDependencyContainer RegisterInstance<T>(this IDependencyContainer container, T instance)
        {
            return container.RegisterInstance(typeof(T), instance);
        }
    }
}