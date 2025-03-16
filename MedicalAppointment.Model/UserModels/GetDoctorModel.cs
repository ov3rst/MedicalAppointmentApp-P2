namespace MedicalAppointment.Model.UserModels
{
    public class GetDoctorModel
    {
        public int DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }
        public string? LicenseNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public short? AvailabilityModeId { get; set; }
        public string? AvailabilityModes { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }
    }
}
