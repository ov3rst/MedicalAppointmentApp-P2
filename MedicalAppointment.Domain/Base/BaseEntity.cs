namespace MedicalAppointment.Domain.Base
{
    /// <summary>
    /// Esta clase abstracta nos sirve de base para que las demas entidades la hereden y no duplicar codigo, aqui van todas las propiedades en comun de las entidades.
    /// </summary>
    /// <typeparam name="TTYpe">El tipo de dato del primary key para realizarla consulta.</typeparam>
    public abstract class BaseEntity<TTYpe>
    {
        /// <summary>
        /// Esta propiedad abstracta es una propiedad en comun que todas las entidades deben tener si o si por eso obligamos a que la implementen.
        /// </summary>
        public abstract TTYpe Id { get; set; }
    }
}
