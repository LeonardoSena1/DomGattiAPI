using System.Diagnostics;

namespace Dev.Host.Components
{
    public class StopWatchStart
    {
        public static Stopwatch Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            return stopwatch;
        }

        public static string Stop(Stopwatch stopwatch)
        {
            stopwatch.Stop();

            return String.Format("Tempo de execução: {0:hh\\:mm\\:ss}", stopwatch.Elapsed);
        }
    }
}