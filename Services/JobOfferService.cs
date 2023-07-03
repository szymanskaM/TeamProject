using Common.Model.JobOffers;
using Infrastructure.Entities;
using Infrastructure.Entities.Main;
using Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly ZespolowyDbContext _context;

        public JobOfferService(ZespolowyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddNewJobOffer(CreateJobOffersDto dto)
        {
            var jobOffer = new JobOffers();
            jobOffer.EmployerId = dto.EmployerId;
            jobOffer.Position = dto.Position;
            jobOffer.Localization = dto.Localization;
            jobOffer.ContractType = dto.ContractType;
            jobOffer.Duties = dto.Duties;
            jobOffer.Requirements = dto.Requirements;
            jobOffer.SalaryMonth = dto.SalaryMonth;
            jobOffer.SalaryHour = dto.SalaryHour;
            jobOffer.WorkingTime = dto.WorkingTime;
            jobOffer.Tittle = dto.Tittle;
            jobOffer.WorkMode = dto.WorkMode;
            jobOffer.PostDate = DateTime.Now;
            jobOffer.PhoneNumber = dto.PhoneNumber;
            jobOffer.Email= dto.Email;
            var creator = _context.Employers.Where(x => x.Id == dto.EmployerId).FirstOrDefault();
            jobOffer.CompanyName = creator.CompanyName;
            _context.JobOffers.Add(jobOffer);
            _context.SaveChanges();
            return new OkObjectResult(jobOffer);
        }

        public async Task<IActionResult> DeleteAnnouncements(long id)
        {
            var announcement= _context.JobOffers.Where(a=>a.Id==id).FirstOrDefault();
            if (announcement!=null)
            {
                _context.JobOffers.Remove(announcement);
                _context.SaveChanges();
            }
            return new OkObjectResult(announcement);
        }

        public async Task<IActionResult> UpdateAnnouncements(UpdateJobOffersDto dto)
        {
            var jobOffer = _context.JobOffers.Where(a => a.Id == dto.Id).FirstOrDefault();
            if (jobOffer != null)
            {
                jobOffer.Position = dto.Position;
                jobOffer.Localization = dto.Localization;
                jobOffer.ContractType = dto.ContractType;
                jobOffer.Duties = dto.Duties;
                jobOffer.Requirements = dto.Requirements;
                jobOffer.SalaryMonth = dto.SalaryMonth;
                jobOffer.SalaryHour = dto.SalaryHour;
                jobOffer.WorkingTime = dto.WorkingTime;
                jobOffer.Tittle = dto.Tittle;
                jobOffer.WorkMode = dto.WorkMode;
                jobOffer.PostDate = DateTime.Now;
                jobOffer.PhoneNumber = dto.PhoneNumber;
                _context.JobOffers.Update(jobOffer);
                _context.SaveChanges();
            }
            return new OkObjectResult(jobOffer);
        }
        public async Task<IActionResult> SelectAnnouncements()
        {
            var announcement = _context.JobOffers.ToList();
            return new OkObjectResult(announcement);
        }
        public Task<IActionResult> SelectAnnouncementsByEmployerId(long userId)
        {
            var announcement =_context.JobOffers.Where(a => a.EmployerId == userId).ToList();
            return Task.FromResult<IActionResult>(new OkObjectResult(announcement));
        }

        public async Task<IActionResult> SearchOneOffer(long id)
        {
            var offer=_context.JobOffers.Where(o=>o.Id == id).FirstOrDefault();
            return new OkObjectResult(offer);
        }
        public async Task<IActionResult> SerchOffersBy(SearchOffersDto dto)
        {
            var offers = new List<JobOffers>();
            if (dto.ContractType == null)
            {
                if (dto.Position == null)
                {
                    if (dto.WorkingTime == null)
                    {
                        if (dto.WorkMode != null)
                        {
                            var modeOffers = _context.JobOffers.Where(o => o.WorkMode == dto.WorkMode);
                            foreach (var o in modeOffers)
                            { offers.Add(o); }
                        }
                        else
                        {
                            offers = _context.JobOffers.ToList();
                        }
                    }
                    else
                    {
                        if (dto.WorkMode == null)
                        {
                            var timeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime);
                            foreach (var o in timeOffers) { offers.Add(o); }
                        }
                        else
                        {
                            var timeModeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.WorkMode == dto.WorkMode);
                            foreach (var o in timeModeOffers) { offers.Add(o); }
                        }
                    }
                }
                else
                {
                    if (dto.WorkingTime == null)
                    {
                        if (dto.WorkMode != null)
                        {
                            var modeOffers = _context.JobOffers.Where(o => o.WorkMode == dto.WorkMode && o.Position==dto.Position);
                            foreach (var o in modeOffers)
                            { offers.Add(o); }
                        }
                        else
                        {
                            offers = _context.JobOffers.Where(o => o.Position==dto.Position).ToList();
                        }
                    }
                    else
                    {
                        if (dto.WorkMode == null)
                        {
                            var timeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.Position == dto.Position);
                            foreach (var o in timeOffers) { offers.Add(o); }
                        }
                        else
                        {
                            var timeModeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.WorkMode == dto.WorkMode && o.Position == dto.Position);
                            foreach (var o in timeModeOffers) { offers.Add(o); }
                        }
                    }
                }
            }
            else
            {
                if (dto.Position == null)
                {
                    if (dto.WorkingTime == null)
                    {
                        if (dto.WorkMode != null)
                        {
                            var modeOffers = _context.JobOffers.Where(o => o.WorkMode == dto.WorkMode && o.ContractType == dto.ContractType);
                            foreach (var o in modeOffers)
                            { offers.Add(o); }
                        }
                        else
                        {
                            offers = _context.JobOffers.Where(o => o.ContractType == dto.ContractType).ToList();
                        }
                    }
                    else
                    {
                        if (dto.WorkMode == null)
                        {
                            var timeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.ContractType == dto.ContractType);
                            foreach (var o in timeOffers) { offers.Add(o); }
                        }
                        else
                        {
                            var timeModeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.WorkMode == dto.WorkMode && o.ContractType == dto.ContractType);
                            foreach (var o in timeModeOffers) { offers.Add(o); }
                        }
                    }
                }
                else
                {
                    if (dto.WorkingTime == null)
                    {
                        if (dto.WorkMode != null)
                        {
                            var modeOffers = _context.JobOffers.Where(o => o.WorkMode == dto.WorkMode && o.Position == dto.Position && o.ContractType == dto.ContractType);
                            foreach (var o in modeOffers)
                            { offers.Add(o); }
                        }
                        else
                        {
                            var positionOffers = _context.JobOffers.Where(o => o.Position == dto.Position && o.ContractType == dto.ContractType);
                            foreach (var o in positionOffers)
                            { offers.Add(o); }
                        }
                    }
                    else
                    {
                        if (dto.WorkMode == null)
                        {
                            var timeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.Position == dto.Position && o.ContractType == dto.ContractType);
                            foreach (var o in timeOffers) { offers.Add(o); }
                        }
                        else
                        {
                            var timeModeOffers = _context.JobOffers.Where(o => o.WorkingTime == dto.WorkingTime && o.WorkMode == dto.WorkMode && o.Position == dto.Position && o.ContractType == dto.ContractType);
                            foreach (var o in timeModeOffers) { offers.Add(o); }
                        }
                    }
                }
            }
            return new OkObjectResult(offers);
        }
        public async Task<IActionResult> SerchOffersByPartOfTitle(string dto)
        {
            var offers = _context.JobOffers.Where(o => o.Tittle.Contains(dto)).ToList();
            return new OkObjectResult(offers);
        }
    }
}
