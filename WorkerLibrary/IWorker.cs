using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerLibrary
{
    public interface IWorker
    {
        Task<string> DoWork(CancellationToken cancellationToken);
    }

    public class Worker : IWorker
    {
        public async Task<string> DoWork(CancellationToken cancellationToken)
        {
            return await BackgroundWorker(cancellationToken).ConfigureAwait(true);
        }
        private static Task<string> BackgroundWorker(CancellationToken cancellationToken)
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

                    Thread.Sleep(500);
                    count++;
                }

                return "Work Done!";
            }, cancellationToken);

        }
    }

}