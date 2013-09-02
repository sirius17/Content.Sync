using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Content.Sync.Infrastructure.Container
{
    [Serializable]
    public class ModuleSettingsSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("modules")]
        [ConfigurationCollection(typeof(ModuleSettingsCollection), AddItemName = "add")]
        public ModuleSettingsCollection Modules
        {
            get
            {
                return this["modules"] as ModuleSettingsCollection;
            }
        }
    }

    [Serializable]
    public class ModuleSettingsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModuleSettings) element).Name;
        }
    }

    [Serializable]
    public class ModuleSettings : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = null, IsRequired = true)]
        public string Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", DefaultValue = null, IsRequired = true)]
        public string Type
        {
            get
            {
                return (String)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        public IContainerInitializer CreateInitializer()
        { 
            return Activator.CreateInstance(System.Type.GetType(this.Type, true)) as IContainerInitializer; 
        }
    }
}
