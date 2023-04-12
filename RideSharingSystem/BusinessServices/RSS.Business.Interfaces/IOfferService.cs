using RSS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
