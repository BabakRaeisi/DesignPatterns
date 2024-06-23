using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter_wrapper_Example 
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class LegacyLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Legacy Logger: {message}");
        }
    }
    public class LoggerAdapter : ILogger
    {
        private readonly LegacyLogger _legacyLogger;

        public LoggerAdapter(LegacyLogger legacyLogger)
        {
            _legacyLogger = legacyLogger;
        }

        public void Log(string message)
        {
            // Adapt the Log method to use the legacy LogMessage method
            _legacyLogger.LogMessage(message);
        }
    }
    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Application is running");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the legacy logger
            LegacyLogger legacyLogger = new LegacyLogger();

            // Create an adapter for the legacy logger
            ILogger loggerAdapter = new LoggerAdapter(legacyLogger);

            // Create the application with the adapter
            Application app = new Application(loggerAdapter);

            // Run the application
            app.Run();
        }
    }

}
