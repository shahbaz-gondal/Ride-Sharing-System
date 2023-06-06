using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public OfferService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public List<OfferModel> GetAll()
        {
            var allOffersList = _UnitOfWork.offers.GetAll();
            var OffersList = allOffersList.Select(x => new OfferModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Cost = x.Cost,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return OffersList;
        }
        public List<OfferModel> myOffers(int userId)
        {
            var myAllOffers = _UnitOfWork.offers.Get(x => x.UserId == userId).ToList();
            var MyOffers = myAllOffers.Select(x => new OfferModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Cost = x.Cost,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return MyOffers;
        }
        public List<OfferModel> SearchRequest(string fromCity, string toCity)
        {
            fromCity = fromCity.Trim().ToLower();
            toCity = toCity.Trim().ToLower();
            var allOffers = _UnitOfWork.offers.Get(x => x.FromCity.ToLower().Contains(fromCity)
            && x.ToCity.ToLower().Contains(toCity)).ToList();
            var searchOffers = allOffers.Select(x => new OfferModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Cost = x.Cost,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return searchOffers;
        }
        public void Add(OfferModel model)
        {
            _UnitOfWork.offers.Add(new Offer
            {
                Id = model.Id,
                FromCity = model.FromCity,
                ToCity = model.ToCity,
                DepartureDateTime = model.DepartureDateTime,
                Cost = model.Cost,
                Status = model.Status,
                UserId = model.UserId
            });
            _UnitOfWork.Save();
        }
        public void Update(OfferModel model)
        {
            _UnitOfWork.offers.Update(new Offer
            {
                Id = model.Id,
                FromCity = model.FromCity,
                ToCity = model.ToCity,
                DepartureDateTime = model.DepartureDateTime,
                Cost = model.Cost,
                Status = model.Status,
                UserId = model.UserId
            });
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
