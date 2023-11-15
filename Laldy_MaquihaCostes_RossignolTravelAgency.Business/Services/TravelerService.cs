//using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
//using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
//using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

//namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
//{
//    public class TravelerService : ITravelerService
//    {
//        private readonly ITravelerRepository repository;

//        public TravelerService(ITravelerRepository repository)
//        {
//            this.repository = repository;
//        }
//        private TravelerDto ModelToDto(Traveler traveler)
//        {
//            TravelerDto travelerDto = new TravelerDto
//            {
//                Id = traveler.Id,
//                FirstName = traveler.FirstName,
//                LastName = traveler.LastName,
//                BirthDate = traveler.BirthDate,
//                TravelList = traveler.TravelList,
//            };

//            return travelerDto;
//        }

//        private Traveler DtoToModel(TravelerDto dto)
//        {
//            Traveler traveler = new Traveler
//            {
//                Id = dto.Id,
//                FirstName = dto.FirstName,
//                LastName = dto.LastName,
//                BirthDate = dto.BirthDate,
//                TravelList = dto.TravelList,
//            };

//            return traveler;
//        }

//        //methodes

//        public async Task<TravelerDto> Add(TravelerDto travelerDto)
//        {
//            Traveler traveler = DtoToModel(travelerDto);
//            await repository.Add(traveler);
//            TravelerDto dto = ModelToDto(traveler);

//            return dto;
//        }

//        public async Task<TravelerDto> Update(TravelerDto travelerDto)
//        {
//            Traveler traveler = DtoToModel(travelerDto);
//            await repository.Update(traveler);
//            TravelerDto dto = ModelToDto(traveler);

//            return dto;
//        }

//        public async Task<TravelerDto> Get(int id)
//        {
//            Traveler traveler = await repository.Get(id);
//            TravelerDto travelerDto = ModelToDto(traveler);
//            return travelerDto;
//        }

//        public async Task<int> Delete(int id)
//        {
//            return await repository.Delete(id);
//        }
//    }
//}
