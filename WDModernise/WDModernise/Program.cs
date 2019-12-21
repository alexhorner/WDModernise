using System;
using WDModernise.Core;

namespace WDModernise
{
    class Program
    {
        private static readonly IWDSentinel _wdSentinel = new WDSentinelHighLevel();

        static void Main(string[] args)
        {
            _wdSentinel.SetLcdLineOne("WDModernise");
            _wdSentinel.SetLcdLineTwo("Please Wait...");
            Console.ReadLine();
            _wdSentinel.Dispose();
            Console.WriteLine("disposed");
            Console.ReadLine();
        }
    }
}
