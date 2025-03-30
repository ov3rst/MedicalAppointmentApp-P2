namespace MedicalAppointment.Application.DTOs.BaseDTOs
{
    public abstract record BaseDTO
    {
        protected BaseDTO()
        {
            ChangeDate = DateTime.Now;
        }

        public DateTime ChangeDate { get; set; }
    }
}
