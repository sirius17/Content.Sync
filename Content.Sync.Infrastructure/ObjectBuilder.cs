using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web;
using Content.Sync.Infrastructure.Container;

namespace Content.Sync.Infrastructure
{
    public static class ObjectBuilder
    {
        private static IDependencyContainer BuildRootContainer()
        {
            var unityContainer = new UnityContainer();
            var rootContainer = new UnityDependencyContainer(unityContainer);
            // Create a list of module initializers and initialize the container
            var section = ConfigurationManager.GetSection("container.modules") as ModuleSettingsSection;
            if (section != null)
            {
                section.Modules
                    .Cast<ModuleSettings>().ToList()
                    .ForEach(m => m.CreateInitializer().Initialize(rootContainer));
            }

            // Read static configuration file if any and load container and override static configuration
            var configuration =
                ConfigurationManager.OpenMappedExeConfiguration(
                    new ExeConfigurationFileMap()
                    {
                        ExeConfigFilename = string.Format(@"{0}\unity.config", App.AppPath)
                    },
                    ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            if (unitySection != null)
                unityContainer.LoadConfiguration(unitySection);
            // To allow for runtime overriding of static configuration, return a child container.
            return new UnityDependencyContainer(rootContainer.InnerContainer.CreateChildContainer());
        }

        private static IDependencyContainer _container = null;
        private static readonly object _syncRoot = new object();

        public static void Reset()
        {
            lock( _syncRoot )
            {
                _container = null;
            }
        }

        private static IDependencyContainer GetContainer()
        {
            if (_container == null)
            {
                lock (_syncRoot)
                {
                    if (_container == null)
                        _container = BuildRootContainer();
                }
            }
            return _container;
        }

        public static object Build(Type interfaceType, string name)
        {
            if (interfaceType == null)
                throw new ArgumentException("interfaceType cannot be null.");
            var container = GetContainer();
            if (string.IsNullOrWhiteSpace(name) == true)
                return container.Resolve(interfaceType);
            else
                return container.Resolve(interfaceType, name);
        }

        public static object Build(Type interfaceType, string name, object args)
        {
            if (interfaceType == null) 
                throw new ArgumentException("interfaceType cannot be null.");
            if (args == null)
                return Build(interfaceType, name);
            var container = GetContainer();
            if (string.IsNullOrWhiteSpace(name) == true)
                return container.Resolve(interfaceType, args);
            else
                return container.Resolve(interfaceType, name, args);
        }

        public static T Build<T>(string name, object args)
        {
            return (T)Build(typeof (T), name, args);
        }

        public static T Build<T>(object args)
        {
            return (T)Build(typeof(T), null, args);
        }

        public static T Build<T>(string name)
            where T : class
        {
            return Build(typeof(T), name) as T;
        }

        public static T Build<T>()
            where T : class
        {
            return Build(typeof(T), null) as T;
        }

        public static object Build(Type interfaceType)
        {
            return Build(interfaceType, null);
        }

        public static object BuildIfDefined(Type interfaceType, string name)
        {
            if (interfaceType == null)
                throw new ArgumentException("interfaceType cannot be null.");
            var container = GetContainer();
            if (container.IsRegistered(interfaceType, name) == false)
                return null;
            if (string.IsNullOrWhiteSpace(name) == true)
                return container.Resolve(interfaceType);
            else
                return container.Resolve(interfaceType, name);
        }

        public static T BuildIfDefined<T>(string name)
            where T : class
        {
            return BuildIfDefined(typeof(T), name) as T;
        }

        public static T BuildIfDefined<T>()
            where T : class
        {
            return BuildIfDefined(typeof(T), null) as T;
        }

        public static object BuildIfDefined(Type interfaceType)
        {
            return BuildIfDefined(interfaceType, null);
        }

        public static List<T> BuildAll<T>()
        {
            return BuildAll(typeof (T)).Cast<T>().ToList();
        }

        public static List<object> BuildAll(Type type)
        {
            if (type == null)
                throw new ArgumentException("type cannot be null.");
            var container = GetContainer();
            return container.ResolveAll(type);
        }

        public static void Register<TFrom,TTo>(string name = null)
            where TTo : TFrom
        {
            var container = GetContainer();
            if (name == null)
                container.RegisterType<TFrom, TTo>();
            else 
                container.RegisterType<TFrom, TTo>(name);
        }

        public static void Register( Type from, Type to, string name = null)
        {
            var container = GetContainer();
            if (name == null)
                container.RegisterType(from, to);
            else
                container.RegisterType(from, to, name);
        }

        public static void RegisterInstance<TFrom>(object instance, string name = null)
        {
            RegisterInstance(typeof(TFrom), instance, name);
        }

        public static void RegisterInstance(Type type, object instance, string name = null)
        {
            var container = GetContainer();
            if (name == null)
                container.RegisterInstance(type, instance);
            else
                container.RegisterInstance(type, instance, name);
        }
    }
}
