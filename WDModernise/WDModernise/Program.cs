using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using WDModernise.Core;

namespace WDModernise
{
    class Program
    {
        public const string ServiceName = "WDModernise";
        private static bool _running;
        private static Thread _serviceThread;

        private static readonly IWDSentinel WDSentinel = new WDSentinelHighLevel();
        private static readonly PerformanceCounter MemoryCounter = new PerformanceCounter();

        /*static void Main(string[] args)
        {
            _wdSentinel.SetLcdLineOne("WDModernise");
            _wdSentinel.SetLcdLineTwo("Please Wait...");
            Console.ReadLine();
            _wdSentinel.Dispose();
            Console.WriteLine("disposed");
            Console.ReadLine();
        }*/


        #region Nested classes to support running as service
        public class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                //Run as a Windows Service
                using (var service = new Service())
                {
                    ServiceBase.Run(service);
                }
            }
            else
            {
                //Run as a Console Application
                Start(args);

                Console.Title = ServiceName;
                Console.WriteLine("WDModernise Service - Debug Mode - Press enter to stop");
                Console.ReadLine();

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            //Start the service
            WDSentinel.SetLcdLineOne("WDModernise");
            WDSentinel.SetLcdLineTwo("Please Wait...");


            MemoryCounter.CategoryName = "Memory";
            MemoryCounter.CounterName = "% Committed Bytes In Use";


            _running = true;
            _serviceThread = new Thread(Run);
            _serviceThread.Start();
        }

        private static void Stop()
        {
            //Stop the service
            _running = false;
            while (_serviceThread.IsAlive)
            {
                //Wait for stop
            }
            WDSentinel.Dispose();
        }

        private static void Run()
        {
            while (_running)
            {
                WDSentinel.SetLcdLineOne("Total Mem (MB)");
                WDSentinel.SetLcdLineTwo($"{MemoryCounter.NextValue()}%");
                Thread.Sleep(100);
            }
        }
    }
}