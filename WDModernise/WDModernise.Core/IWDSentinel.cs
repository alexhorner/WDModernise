using System;

namespace WDModernise.Core
{
    public interface IWDSentinel : IDisposable
    {
        /// <summary>
        /// Initialise the LCD display. This method is called when the object is instantiated
        /// </summary>
        void InitialiseLcd();
        
        /// <summary>
        /// Clear the contents of the LCD display
        /// </summary>
        void ClearLcd();

        /// <summary>
        /// Set the contrast of the LCD display
        /// </summary>
        /// <param name="contrast">Value between 0 and 3</param>
        void SetLcdContrast(int contrast);

        /// <summary>
        /// Set line 1 of the LCD display
        /// </summary>
        /// <param name="line">Characters over the 16 character limit are cut off</param>
        void SetLcdLineOne(string line);

        /// <summary>
        /// Set line 2 of the LCD display
        /// </summary>
        /// <param name="line">Characters over the 16 character limit are cut off</param>
        void SetLcdLineTwo(string line);

        /// <summary>
        /// Set the system fan PWM speed
        /// </summary>
        /// <param name="speed">Value between 0 and 255</param>
        void SetSystemFanSpeed(int speed);
    }
}
