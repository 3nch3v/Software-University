using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        public Stopwatch watch;
        private readonly HashSet<string> laps;

        public Chronometer()
        {
            this.laps = new HashSet<string>();
            this.watch = new Stopwatch();
        }

        public IReadOnlyCollection<string> Laps => (IReadOnlyCollection<string>)laps;

        public string GetTime => watch.Elapsed.ToString("c");

        public string Lap()
        {
            var lap = watch.Elapsed.ToString("c");
            this.laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            watch.Reset();
            this.laps.Clear();
        }

        public void Start()
        {
            this.watch.Start();
        }

        public void Stop()
        {
            this.watch.Stop();
        }
    }
}
