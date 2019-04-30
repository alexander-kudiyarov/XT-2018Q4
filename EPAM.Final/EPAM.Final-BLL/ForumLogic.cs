[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EPAM.Final_BLL
{
    public abstract class ForumLogic
    {
        protected static readonly log4net.ILog Log = LogHelper.GetLogger();

        protected static int ErrorCode { get; } = -1;
    }
}