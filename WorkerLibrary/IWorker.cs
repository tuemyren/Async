using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerLibrary
{
    public interface IWorker
    {
        void DoWork(Action finalize);
    }

    public class Worker : IWorker   
    {
        public void DoWork(Action finalize)
        {
            var t = new Task(() =>
            {
                Thread.Sleep(5000);
                finalize?.Invoke();
            });
            t.Start();
        }
    }
}