namespace WDModernise.Core
{
    public class WDSentinelMidLevel : IWDSentinel
    {
        /*
         * This class does not work yet.
         *
         * The intent of the Mid Level class is to use the DLL files which are already provided in the same location as the executables
         * used in the High Level class. These DLL files are what the executables use to operate, but I have not had luck instantiating
         * the objects within them, as I believe they're written in C++ and this C# application does not immediately play nicely.
         *
         * If someone is able to write this Mid Level implementation using the WD DLL files, that would be awesome. Remember, you cannot
         * include the DLLs in your commit because they are owned by WD and therefore may legally not be redistributable.
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
