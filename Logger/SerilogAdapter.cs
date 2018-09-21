using Serilog;
using System;

namespace Logger
{
    public class SerilogAdapter
    {
        private static ILogger _logger;
        private static string template = "{Timestamp:yyyy-MMM-dd HH:mm::ss} [{Level}] {Message}{NewLine}{Exception}";


        static SerilogAdapter()
        {
            _logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.ColoredConsole(Serilog.Events.LogEventLevel.Verbose, outputTemplate: template)
                            .WriteTo.File("log.txt")
                            .WriteTo.RollingFile("rollinglogfile.txt", retainedFileCountLimit: 2)
                            .CreateLogger();

            Log.Logger = _logger;
        }

        private static ILogger Logger {
            get { return Log.Logger; }
            set { }
        }

        public void LogMessage(string message)
        {
            Logger.Debug(message);
            Logger.Information(message);
            Logger.Warning(message);
            Logger.Error(message);
            Logger.Fatal(message);
        }

    }
}
