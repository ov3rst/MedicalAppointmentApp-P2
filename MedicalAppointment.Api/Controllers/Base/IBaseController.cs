using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.Base
{
    public interface IBaseController<TEntity, TType> where TEntity : class
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByIdAsync(TType id);
        Task<IActionResult> SaveAsync(TEntity entity);
        Task<IActionResult> UpdateAsync(TEntity entity);
        Task<IActionResult> RemoveAsync(TType id);
    }
}
