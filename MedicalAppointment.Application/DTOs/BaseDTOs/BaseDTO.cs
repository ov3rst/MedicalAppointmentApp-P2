namespace MedicalAppointment.Application.DTOs.BaseDTOs
{
    public abstract record BaseDTO
    {
        public DateTime ChangeDate { get; set; }
    }
}
