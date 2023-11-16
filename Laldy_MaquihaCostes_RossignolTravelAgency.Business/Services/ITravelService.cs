using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface ITravelService
    {
        Task<TravelDto> Add(TravelDto travelDto);
        Task<int> Delete(int id);
        Task<TravelDto> Get(int id);
        Task<TravelDto> Update(TravelDto travelDto);
        List<TravelDto> GetFutureTravel();
        List<TravelDto> GetPastTravel();

    }
}