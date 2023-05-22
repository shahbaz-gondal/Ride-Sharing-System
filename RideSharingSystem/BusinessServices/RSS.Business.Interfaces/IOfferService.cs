using RSS.Business.Models;

namespace RSS.Business.Interfaces
{
    public interface IOfferService
    {
        public List<OfferModel> GetAll();
        public List<OfferModel> myOffers(int userId);
        public List<OfferModel> SearchRequest(string fromCity, string toCity);
        public void Add(OfferModel model);
        public void Update(OfferModel model);
        public void Delete(int id);
    }
}
