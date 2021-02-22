using System;
using System.ComponentModel;
using System.Threading;

namespace WorkerLibrary
{
    public interface IWorker
    {
        void DoWork();
    }

    public class Worker : IWorker   
    {
        public void DoWork()
        {
            Thread.Sleep(5000);
        }
    }
}