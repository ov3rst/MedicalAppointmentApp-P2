namespace MedicalAppointment.Domain.SecurityInterfaces
{
    public interface ILoggerService<T> where T : class
    {
        void LogError(string message, Exception ex = null!);
        void LogInformation(string message);
    }
}
