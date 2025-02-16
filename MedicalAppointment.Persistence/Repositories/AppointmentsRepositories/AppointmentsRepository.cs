using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;

namespace MedicalAppointment.Persistence.Repositories.AppointmentsRepositories
{
    public class AppointmentsRepository : BaseRepository<Appointments, int>
    {
        private readonly AppointmentDbContext _context;

        public AppointmentsRepository(AppointmentDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OperationResult> SaveEntityAsync(Appointments entity)
        {
            OperationResult result = new();

            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula";
                return result;
            }

            if (entity!.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El doctor no debe ser nulo";
                return result;
            }

            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El paciente no debe ser nulo";
                return result;
            }

            if (entity.AppointmentDate <= DateTime.Now)
            {
                result.Success = false;
                result.Message = $"La fecha de la cita es invalida";
                return result;
            }

            if (await base.ExistsAsync(e => e.Id == entity.Id))
            {
                result.Success = false;
                result.Message = "La entidad ya existe en la base de datos";
                return result;
            }

            try
            {
                result.Data = await base.SaveEntityAsync(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ha ocurrido el error: {ex.Message}, guardando la entidad";
                throw;
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Appointments entity)
        {
            OperationResult result = new();

            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula";
                return result;
            }

            if (entity!.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El doctor no debe ser nulo";
                return result;
            }

            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El paciente no debe ser nulo";
                return result;
            }

            if (entity.AppointmentDate <= DateTime.Now)
            {
                result.Success = false;
                result.Message = $"La fecha de la cita es invalida";
                return result;
            }

            try
            {
                result.Data = await base.UpdateEntityAsync(entity);
                result.Message = "La cita ha sido actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ha ocurrido el error: {ex.Message}, guardando la entidad";
            }

            return result;
        }
    }
}
