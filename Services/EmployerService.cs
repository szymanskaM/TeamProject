using Common.Model.Users;
using Infrastructure.Entities;
using Infrastructure.Entities.Main;
using Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Services
{
    public class EmployerService:IEmployerService
    {
        private readonly ZespolowyDbContext _context;

        public EmployerService(ZespolowyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AddUser(CreateEmployerDto dto)
        {
            var users = _context.Employers.Where(u => u.Login==dto.Login).FirstOrDefault();
            if (users == null && dto.Password.Length > 7 && Regex.Match(dto.Password,"[A-Z]+").Success)
            {
                Employers user = new Employers();
                user.Login=dto.Login;
                user.Password = dto.Password;
                user.CompanyName = dto.CompanyName;
                _context.Employers.Add(user);
                _context.SaveChanges();
                return new OkObjectResult(user);
            }
            var usersZero = _context.Employers.Where(u => u.Login == "").FirstOrDefault();
            return new OkObjectResult(usersZero);
        }

        public async Task<IActionResult> CheckUser(CheckLog log)
        {
            var user=_context.Employers.Where(u=>u.Login == log.Login && u.Password==log.Password).FirstOrDefault();
            return new OkObjectResult(user);
        }

        public async Task<IActionResult> UpdateUser(UpdateEmployerDto dto)
        {
            var user = _context.Employers.Where(u => u.Id == dto.Id && u.Password == dto.Password).FirstOrDefault();
            if (user != null)
            {
                user.Login = dto.Login;
                user.Password = dto.Password;
                user.CompanyName=dto.CompanyName;
                _context.Employers.Update(user);    
            }
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}