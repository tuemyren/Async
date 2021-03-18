using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerLibrary
{
    public interface IWorker
    {
        Task<string> DoWork(CancellationToken cancellationToken, int ms = 500);
    }

    public class Worker : IWorker
    {
        public async Task<string> DoWork(CancellationToken cancellationToken, int ms)
        {
            return await BackgroundWorker(cancellationToken, ms).ConfigureAwait(true);
        }
        private static Task<string> BackgroundWorker(CancellationToken cancellationToken, int ms)
        {
            return Task.Run(() =>
            {
                var count = 0; 
                while (count < 10)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return "Work cancelled!";
                    }

                    Thread.Sleep(ms);
                    count++;
                }

                return "Work Done!";
            }, cancellationToken);

        }
    }

}