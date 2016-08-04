#if DEBUG
using NLog;

namespace TagDataTranslation
{
    internal static class Log
    {
        public static Logger Instance { get; private set; }

        static Log ()
        {
            LogManager.ReconfigExistingLoggers ();

            Instance = LogManager.GetCurrentClassLogger ();
        }
    }
}
#endif