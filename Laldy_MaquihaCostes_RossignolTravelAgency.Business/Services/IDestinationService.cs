using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface IDestinationService
    {
        Task<DestinationDto> Add(DestinationDto destinationDto);
        Task<int> Delete(int id);
        Task<DestinationDto> Get(int id);
        //get all
        Task<DestinationDto> Update(DestinationDto destinationDto);
    }
}