using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkerLibrary;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public async Task DoWork_RunToCompletion_ReturnsWorkDone()
        {
            CancellationToken ct = new CancellationToken();
            Worker worker = new Worker();
            Assert.AreNotEqual("Work Done!", await worker.DoWork(ct));
        }
    }
}
