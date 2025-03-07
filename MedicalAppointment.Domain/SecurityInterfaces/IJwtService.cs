namespace MedicalAppointment.Domain.SecurityInterfaces
{
    public interface IJwtService
    {
        public string GenerateJwt(string firstName, string email, string role);
    }
}
