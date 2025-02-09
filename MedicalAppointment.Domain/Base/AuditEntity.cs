namespace MedicalAppointment.Domain.Base
{
    /// <summary>
    /// Esta clase tambien es una clase base solo que la separamos porque hay entidades que no necesitan tener estas propiedades.
    /// </summary>
    /// <typeparam name="TType">El tipo de dato del primary key para realizarla consulta.</typeparam>
    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
