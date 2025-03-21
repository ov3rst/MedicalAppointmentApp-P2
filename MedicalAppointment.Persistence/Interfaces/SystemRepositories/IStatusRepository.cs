﻿using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Domain.Repository;

namespace MedicalAppointment.Persistence.Interfaces.SystemRepositories
{
    public interface IStatusRepository : IBaseRepository<Status, int>
    {
    }
}
