using System.Xml;
using Microsoft.Practices.Unity.Configuration;

namespace Content.Sync.Infrastructure.Container
{
    internal class UnityConfiguration : UnityConfigurationSection
    {
        internal UnityConfiguration(string path)
        {
            using (var reader = XmlReader.Create(path))
            {
                this.DeserializeSection(reader);
            }
        }

        internal UnityConfiguration(XmlReader reader)
        {
            this.DeserializeSection(reader);
        }

        protected override sealed void DeserializeSection(XmlReader reader)
        {
            base.DeserializeSection(reader);
        }
    }
}