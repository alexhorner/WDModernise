namespace WDModernise.Core
{
    public class WDSentinelLowLevel : IWDSentinel
    {
        /*
         * This class does not work yet.
         *
         * The intent of the Low Level class is to write a complete implementation of the communication with the hardware components of
         * the NAS. We don't want to use any WD DLLs here, and instead write as much as possible, using only Open Source libraries which
         * are under or compatible with the MIT license this software uses, and even then the less libraries that are used the better.
         *
         * If someone is able to write this Low Level implementation, that would be awesome!
         */

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void InitialiseLcd()
        {
            throw new System.NotImplementedException();
        }

        public void ClearLcd()
        {
            throw new System.NotImplementedException();
        }

        public void SetLcdContrast(int contrast)
        {
            throw new System.NotImplementedException();
        }

        public void SetLcdLineOne(string line)
        {
            throw new System.NotImplementedException();
        }

        public void SetLcdLineTwo(string line)
        {
            throw new System.NotImplementedException();
        }

        public void SetSystemFanSpeed(int speed)
        {
            throw new System.NotImplementedException();
        }
    }
}
