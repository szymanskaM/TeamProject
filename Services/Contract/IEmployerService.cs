using Common.Model.Users;
using Microsoft.AspNetCore.Mvc;

namespace Services.Contract
{
    public interface IEmployerService
    {
        Task<IActionResult> AddUser(CreateEmployerDto dto);
        Task<IActionResult> CheckUser(CheckLog log);
        Task<IActionResult> UpdateUser(UpdateEmployerDto dto);
    }
}
