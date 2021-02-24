using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerLibrary
{
    public interface IWorker
    {
        Task DoWork();
    }

    public class Worker : IWorker
    {
        public async Task DoWork()
        {
            await BackgroundWorker();
        }
        private static Task BackgroundWorker()
        {
            return Task.Run(() => Thread.Sleep(5000));
        }
    }

}