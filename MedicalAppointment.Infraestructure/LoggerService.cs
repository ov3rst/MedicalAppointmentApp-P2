using MedicalAppointment.Domain.SecurityInterfaces;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Infraestructure
{
    public class LoggerService<T>(ILogger<T> logger) : ILoggerService<T> where T : class
    {
        private readonly ILogger<T> _logger = logger;

        public void LogError(string message, Exception ex = null!)
        {
            if (ex is null) _logger.LogError(message);
            else _logger.LogError(message, ex);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
