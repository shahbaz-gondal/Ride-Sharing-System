using AutoMapper;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<OfferModel> GetAll()
        {
            var allOffersList = _UnitOfWork.offers.GetAll();
            var OffersList = _mapper.Map<List<OfferModel>>(allOffersList);
            return OffersList;
        }
        public List<OfferModel> myOffers(int userId)
        {
            var myAllOffers = _UnitOfWork.offers.Get(x => x.UserId == userId).ToList();
            var MyOffers = _mapper.Map<List<OfferModel>>(myAllOffers);
            return MyOffers;
        }
        public List<OfferModel> SearchOffers(string fromCity, string toCity)
        {
            fromCity = fromCity.Trim().ToLower();
            toCity = toCity.Trim().ToLower();

            var allOffers = _UnitOfWork.offers.Get(x => x.FromCity.ToLower().Contains(fromCity)
            && x.ToCity.ToLower().Contains(toCity)).ToList();

            var searchOffers = _mapper.Map<List<OfferModel>>(allOffers);
            return searchOffers;
        }
        public void Add(OfferModel model)
        {
            var entity = _mapper.Map<Offer>(model);
            _UnitOfWork.offers.Add(entity);
            _UnitOfWork.Save();
        }
        public void Update(OfferModel model)
        {
            var entity = _mapper.Map<Offer>(model);
            _UnitOfWork.offers.Update(entity);
            _UnitOfWork.Save();
        }
        public void Delete(int id)
        {
            var offer = _UnitOfWork.offers.Get(x => x.Id == id).FirstOrDefault();
            if (offer != null)
            {
                _UnitOfWork.offers.Delete(offer);
                _UnitOfWork.Save();
            }
        }
    }
}
