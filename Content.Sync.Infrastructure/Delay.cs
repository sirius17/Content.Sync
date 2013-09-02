using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Infrastructure
{
    public class IncrementalDelay
    {
        public IncrementalDelay(int stepSizeInSeconds, int maxDelayInSeconds)
        {
            if (maxDelayInSeconds < stepSizeInSeconds)
                throw new ArgumentException("MaxDelay cannot be less than StepSize.");
            this.Delay = 0;
        }

        private int Delay { get; set; }

        public int StepSizeInSeconds { get; private set; }

        public int MaxDelayInSeconds { get; private set; }

        public async Task Wait()
        {
            this.Delay = Math.Min( this.Delay + this.StepSizeInSeconds, this.MaxDelayInSeconds);
            await Task.Delay(new TimeSpan(0,0,this.Delay));
        }

        public void Reset()
        {
            this.Delay = 0;
        }

    }
}
