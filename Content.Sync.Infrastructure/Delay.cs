using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Sync.Infrastructure
{
    public class IncrementalDelay
    {
        //TODO: Move step size inside the incremental delay class
        public IncrementalDelay(int stepSizeInSeconds, int minDelayInSeconds, int maxDelayInSeconds)
        {
            if (maxDelayInSeconds < stepSizeInSeconds)
                throw new ArgumentException("MaxDelay cannot be less than StepSize.");
            this.MinDelayInSeconds = minDelayInSeconds;
            this.MaxDelayInSeconds = maxDelayInSeconds;
        }

        private int _count = 0;

        public int StepSizeInSeconds { get; private set; }

        public int MinDelayInSeconds { get; private set; }

        public int MaxDelayInSeconds { get; private set; }

        public async Task Wait()
        {
            var delay = Math.Min(this.MinDelayInSeconds + _count * this.StepSizeInSeconds, this.MaxDelayInSeconds);
            _count++;
            await Task.Delay(new TimeSpan(0,0, delay));
        }

        public void Reset()
        {
            _count = 0;
        }

    }
}
