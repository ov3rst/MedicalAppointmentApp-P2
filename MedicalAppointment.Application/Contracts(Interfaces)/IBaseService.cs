﻿using MedicalAppointment.Domain.Base;

namespace MedicalAppointment.Application.Contracts_Interfaces_
{
    public interface IBaseService<TDtoSave, TDtoUpdate, TDtoRemove, TType>
    {
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(TType id);
        Task<OperationResult> Save(TDtoSave data);
        Task<OperationResult> Update(TDtoUpdate data);
        Task<OperationResult> Remove(TDtoRemove data);

    }
}
