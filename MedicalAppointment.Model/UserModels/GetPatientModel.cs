namespace MedicalAppointment.Model.UserModels
{
    public class GetPatientModel
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public int InsuranceProviderId { get; set; }
        public string? InsuranceName { get; set; }
        public string? CoverageDetails { get; set; }
        public decimal? MaxCoverageAmount { get; set; }
    }
}
