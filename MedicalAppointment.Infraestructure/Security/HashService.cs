using MedicalAppointment.Domain.SecurityInterfaces;
using System.Security.Cryptography;
using System.Text;

namespace MedicalAppointment.Infraestructure.Security
{
    public class HashService : IHashService
    {
        public string HashearPassword(string password)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] computePass = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder pass = new();
                foreach (byte b in computePass)
                {
                    pass.Append(b.ToString("x2"));
                }

                return pass.ToString();
            }
        }

        public bool VerifyPassword(string password, string passwordHash) => HashearPassword(password).Equals(passwordHash);
    }
}
