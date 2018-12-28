using System;

namespace EverLog
{
    public static class Utils
    {
        public static string GetInnerExceptionMsgs(Exception ex)
        {
            var statusMsg = string.Empty;

            if (!ex.Message.Contains("See the inner exception for details"))
            {
                statusMsg = ex.Message;
                if (ex.InnerException != null)
                {
                    statusMsg += ex.InnerException.Message;
                }
            }
            else
            {
                if (ex.InnerException != null)
                {
                    if (!ex.InnerException.Message.Contains("See the inner exception for details"))
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            statusMsg = ex.InnerException.InnerException.Message;
                        }
                    }
                    else
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            statusMsg += ex.InnerException.InnerException.Message;
                        }
                    }
                }
            }
            return statusMsg;
        }

    }
}
