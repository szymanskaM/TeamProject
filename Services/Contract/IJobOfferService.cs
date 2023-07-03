using Common.Model.JobOffers;
using Microsoft.AspNetCore.Mvc;

namespace Services.Contract
{
    public interface IJobOfferService
    {
        Task<IActionResult> AddNewJobOffer(CreateJobOffersDto dto);
        Task<IActionResult> DeleteAnnouncements(long id);
        Task<IActionResult> SelectAnnouncements();
        Task<IActionResult> SelectAnnouncementsByEmployerId(long userId);
        Task<IActionResult> SerchOffersBy(SearchOffersDto dto);
        Task<IActionResult> UpdateAnnouncements(UpdateJobOffersDto dto);
        Task<IActionResult> SearchOneOffer(long id);
        Task<IActionResult> SerchOffersByPartOfTitle(string dto);
    }
}
