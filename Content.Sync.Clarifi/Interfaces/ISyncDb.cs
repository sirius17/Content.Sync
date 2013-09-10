using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public interface ISyncDb
    {
        Task<IEnumerable<BotSettings>> GetBotSettings(string deploymentName);

        Task CheckpointRevision(string botId, long revision);
    }
}
