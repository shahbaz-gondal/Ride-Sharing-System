using RSS.Business.Models;

namespace RSS.Business.Interfaces
{
    public interface IRequestService
    {
        public List<RequestModel> GetAll();
        public List<RequestModel> myRequests(int userId);
        public List<RequestModel> SearchRequest(string fromCity, string toCity);
        public void Add(RequestModel model);
        public void Update(RequestModel model);
        public void Delete(int id);
    }
}