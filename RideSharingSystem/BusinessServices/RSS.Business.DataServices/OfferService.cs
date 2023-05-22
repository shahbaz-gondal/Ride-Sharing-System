using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> _DbContext;
        public OfferService(IRepository<Offer> dbContext)
        {
            _DbContext = dbContext;
        }

        public List<OfferModel> GetAll()
        {
            var allOffersList = _DbContext.GetAll();
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
            var myAllOffers = _DbContext.Get(x => x.UserId == userId).ToList();
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
            var allOffers = _DbContext.Get(x => x.FromCity.ToLower().Contains(fromCity)
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
            _DbContext.Add(new Offer
            {
                Id = model.Id,
                FromCity = model.FromCity,
                ToCity = model.ToCity,
                DepartureDateTime = model.DepartureDateTime,
                Cost = model.Cost,
                Status = model.Status,
                UserId = model.UserId
            });
        }
        public void Update(OfferModel model)
        {
            _DbContext.Update(new Offer
            {
                Id = model.Id,
                FromCity = model.FromCity,
                ToCity = model.ToCity,
                DepartureDateTime = model.DepartureDateTime,
                Cost = model.Cost,
                Status = model.Status,
                UserId = model.UserId
            });
        }
        public void Delete(int id)
        {
            var offer = _DbContext.Get(x => x.Id == id).FirstOrDefault();
            if (offer != null)
            {
                _DbContext.Delete(offer);
            }
        }
    }
}
