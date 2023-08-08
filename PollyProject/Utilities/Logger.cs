using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;

namespace PollyProject.Utilities
{
    public static class Logger
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";


        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text"></param>
        public static void Debug(string text)
        {
            WriteFormattedLog(LogLevel.Debug, text);
        }
        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text"></param>
        public static void Error(string text)
        {
            WriteFormattedLog(LogLevel.Error, text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text"></param>
        public static void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.Fatal, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text"></param>
        public static void Info(string text)
        {
            WriteFormattedLog(LogLevel.Info, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text"></param>
        public static void Trace(string text)
        {
            WriteFormattedLog(LogLevel.Trace, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text"></param>
        public static void Warning(string text)
        {
            WriteFormattedLog(LogLevel.Warning, text);
        }

        private static void WriteLine(string text)
        {
            TestContext.Progress.WriteLine(text);
        }

        private static void WriteFormattedLog(LogLevel level, string text)
        {
            var pretext = level switch
            {
                LogLevel.Trace => DateTime.Now.ToString(DateTimeFormat) + " [TRACE]   ",
                LogLevel.Info => DateTime.Now.ToString(DateTimeFormat) + " [INFO]    ",
                LogLevel.Debug => DateTime.Now.ToString(DateTimeFormat) + " [DEBUG]   ",
                LogLevel.Warning => DateTime.Now.ToString(DateTimeFormat) + " [WARNING] ",
                LogLevel.Error => DateTime.Now.ToString(DateTimeFormat) + " [ERROR]   ",
                LogLevel.Fatal => DateTime.Now.ToString(DateTimeFormat) + " [FATAL]   ",
                _ => ""
            };

            WriteLine(pretext + text);
        }

        [Flags]
        private enum LogLevel
        {
            Trace,
            Info,
            Debug,
            Warning,
            Error,
            Fatal
        }
    }
}