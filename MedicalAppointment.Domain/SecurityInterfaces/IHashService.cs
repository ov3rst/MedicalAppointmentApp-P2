namespace MedicalAppointment.Domain.SecurityInterfaces
{
    public interface IHashService
    {
        public string HashearPassword(string password);
        public bool VerifyPassword(string password, string passwordHash);
    }
}
