namespace MedicalAppointment.Application.DTOs.BaseDTOs
{
    public abstract record BaseActiveDTO : BaseDTO
    {
        protected BaseActiveDTO()
        {
            this.IsActive = true;
        }
        public bool IsActive { get; set; }
    }
}
