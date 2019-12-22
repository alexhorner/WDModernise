using System;
using System.Diagnostics;
using System.Threading;

namespace WDModernise.Core
{
    public class WDSentinelHighLevel : IWDSentinel
    {
        private readonly Process _systemHandlerProcess = new Process();
        private readonly Process _lcdHandlerProcess = new Process();

        public WDSentinelHighLevel()
        {
            _systemHandlerProcess.StartInfo.FileName = @"C:\Program Files\Western Digital\LPC Driver\sioutil.exe";
            _systemHandlerProcess.StartInfo.CreateNoWindow = true;
            _systemHandlerProcess.StartInfo.RedirectStandardInput = true;
            _systemHandlerProcess.StartInfo.UseShellExecute = false;
            _systemHandlerProcess.Start();

            _lcdHandlerProcess.StartInfo.FileName = @"C:\Program Files\Western Digital\WD LCD Provider\lcd.exe";
            _lcdHandlerProcess.StartInfo.CreateNoWindow = true;
            _lcdHandlerProcess.StartInfo.UseShellExecute = false;

            SetSystemFanSpeed(5); //Slow the fan down to make things quieter 
            InitialiseLcd(); //Prepare the LCD for data
            SetLcdContrast(0); //Make the LCD as visible as possible
        }

        private void ExecuteLcdFunction(string function)
        {
            _lcdHandlerProcess.StartInfo.Arguments = function;
            _lcdHandlerProcess.Start();
            while (!_lcdHandlerProcess.HasExited)
            {
                //Wait
            }
        }

        public void InitialiseLcd()
        {
            ExecuteLcdFunction("init");
        }

        public void ClearLcd()
        {
            ExecuteLcdFunction("clear");
        }

        public void SetLcdContrast(int contrast)
        {
            if (contrast > 3 || contrast < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(contrast), "Value must be between 0 and 3");
            }

            _systemHandlerProcess.StandardInput.WriteLine($"setcontrast {contrast}");
        }

        public void SetLcdLineOne(string line)
        {
            ExecuteLcdFunction($"0 \"{line}\"");
        }

        public void SetLcdLineTwo(string line)
        {
            ExecuteLcdFunction($"1 \"{line}\"");
        }

        public void SetSystemFanSpeed(int speed)
        {
            if (speed > 255 || speed < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), "Value must be between 0 and 255");
            }

            _systemHandlerProcess.StandardInput.WriteLine($"setfan sysfan {speed}");
        }

        public void Dispose()
        {
            _systemHandlerProcess.StandardInput.WriteLine("exit");
            while (!_systemHandlerProcess.HasExited || !_lcdHandlerProcess.HasExited)
            {
                Thread.Sleep(10);
            }
            _systemHandlerProcess.Dispose();
            _lcdHandlerProcess.Dispose();
        }
    }
}
