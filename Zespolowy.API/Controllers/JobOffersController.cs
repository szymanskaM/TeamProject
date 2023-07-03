using Common.Model.JobOffers;
using Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Zespolowy.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class JobOffersController : Controller
    {
        private readonly IJobOfferService _announcementService;

        public JobOffersController(IJobOfferService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        [Route("/api/offer")]
        public async Task<IActionResult> AddAnnouncements(CreateJobOffersDto dto)
        {
            return await _announcementService.AddNewJobOffer(dto);
        }
        [HttpDelete]
        [Route("/api/offer/{id}")]
        public async Task<IActionResult> DeleteAnnouncements(long id)
        {
            return await _announcementService.DeleteAnnouncements(id);
        }
        [HttpPatch]
        [Route("/api/offer")]
        public async Task<IActionResult> UpdateAnnouncements(UpdateJobOffersDto dto)
        {
            return await _announcementService.UpdateAnnouncements(dto);
        }
        [HttpGet]
        [Route("/api/offer")]
        public async Task<IActionResult> SelectAnnouncements()
        {
            return await _announcementService.SelectAnnouncements();
        }
        [HttpGet]
        [Route("/api/offer/user/{userId}")]
        public async Task<IActionResult> SelectAnnouncementsByUserId(long userId)
        {
            return await _announcementService.SelectAnnouncementsByEmployerId(userId);
        }
        [HttpPost]
        [Route("/api/offer/special")]
        public async Task<IActionResult> SearchOffersBy(SearchOffersDto dto)
        {
            return await _announcementService.SerchOffersBy(dto);
        }
        [HttpGet]
        [Route("/api/offer/{offerId}")]
        public async Task<IActionResult> SelectAnnouncementById(long offerId)
        {
            return await _announcementService.SearchOneOffer(offerId);
        }
        [HttpGet]
        [Route("/api/offer/part/{title}")]
        public async Task<IActionResult> SerchOffersByPartOfTitle(string title)
        {
            return await _announcementService.SerchOffersByPartOfTitle(title);
        }
    }
}
