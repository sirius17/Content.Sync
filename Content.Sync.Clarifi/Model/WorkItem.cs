using Content.Sync.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public abstract class WorkItem
    {
        public string Id { get; set; }

        public long Revision { get; set; }

        public DateTime UtcCreateDate { get; set; }

        public DateTime UtcLastUpdated { get; set; }

        private ConcurrentDictionary<string, string> _properties = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        protected IEnumerable<string> Keys
        {
            get
            {
                return _properties.Keys;
            }
        }

        protected string this[string name]
        {
            get 
            {
                string output = null;
                if (_properties.TryGetValue(name, out output) == true)
                    return output;
                else return null;
            }
            set
            {
                _properties[name] = value;
            }
        }

        public async Task Do(CancellationToken cancellationToken)
        {
            // Specification
            // Each task will build the specific command that is required to execute it.
            // and delegate the execution the the command.

            var factory = ObjectBuilder.Build<IWorkItemCommandFactory>(this.GetType().Name);
            var command = factory.BuildCommand(this);
            await command.Execute(this, cancellationToken);
        }

	    public Task MarkAsFaultedAsync(List<Exception> faults)
        {
            throw new NotImplementedException();
        }

        internal async Task CheckpointRevision(string botId)
        {
            var db = ObjectBuilder.Build<ISyncDb>();
            await db.CheckpointRevision(botId, this.Revision);
        }    
    }

 	public enum ChangeType
    {
        Added,
        Updated,
        Deleted
    }

    public enum Schema
    {
        Hotel,
        SupplierHotel,
        SupplierFamily,
        Amenity,
        AmenityGroup,
        Attration,
        InOutDetail,
        Description,
        Detail,
        Policy,
        CancellationPolicy,
        Chain,
        TagGroup,
        Tag,
        SupplierTag,
        ActivityGroup,
        HotelActivity,
        Image
    }
}
