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
        public Task DoWork()
        {
            return Task.Run(() => Thread.Sleep(5000));
        }
    }
}