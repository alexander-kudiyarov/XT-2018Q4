using System.Runtime.CompilerServices;

namespace EPAM.Final_DAL
{
    public static class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}