namespace MedicalAppointment.Domain.Base
{
    /// <summary>
    /// Esta clase tambien es una clase base solo que la separamos porque hay entidades que no necesitan tener estas propiedades.
    /// </summary>
    /// <typeparam name="TType">El tipo de dato del primary key para realizarla consulta</typeparam>
    public abstract class ActiveEntity<TType> : AuditEntity<TType>
    {
        public bool IsActive { get; set; }
    }
}
