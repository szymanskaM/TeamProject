using Common.Model.Users;
using Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Zespolowy.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class EmployerController : Controller
    {
        private readonly IEmployerService _userService;

        public EmployerController(IEmployerService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("/api/user/log")]
        public async Task<IActionResult> CheckUser(CheckLog log)
        {
            return await _userService.CheckUser(log);
        }
        [HttpPost]
        [Route("/api/user")]
        public async Task<IActionResult> AddUser(CreateEmployerDto dto)
        {
            return await _userService.AddUser(dto);
        }
        [HttpPatch]
        [Route("/api/user")]
        public async Task<IActionResult> UpdateUser(UpdateEmployerDto dto)
        {
            return await _userService.UpdateUser(dto);
        }
    }
}
