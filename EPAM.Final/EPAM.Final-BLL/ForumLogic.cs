using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EPAM.Final_BLL
{
    public abstract class ForumLogic
    {
        protected static int errorCode = -1;

        protected static readonly log4net.ILog log = LogHelper.GetLogger();
    }
}
