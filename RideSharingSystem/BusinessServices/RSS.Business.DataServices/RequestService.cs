using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class RequestService:IRequestService
    {
        private readonly IRepository<Request> _DBcontext;
        public RequestService(IRepository<Request> DBcontext)
        {
            _DBcontext = DBcontext;
        }
        public List<RequestModel> GetAll()
        {
            var allRequestsList = _DBcontext.GetAll();
            var RequestsList = allRequestsList.Select(x => new RequestModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Fare = x.Fare,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return RequestsList;
        }
        public List<RequestModel> myRequests(int userId)
        {
            var myAllRequests = _DBcontext.Get(x => x.UserId == userId).ToList();
            var MyRequests = myAllRequests.Select(x => new RequestModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Fare = x.Fare,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return MyRequests;
        }
        public List<RequestModel> SearchRequest(string fromCity, string toCity)
        {
            fromCity = fromCity.Trim().ToLower();
            toCity = toCity.Trim().ToLower();
            var allRequests = _DBcontext.Get(x => x.FromCity.ToLower().Contains(fromCity)
            && x.ToCity.ToLower().Contains(toCity)).ToList();

            var searchRequests = allRequests.Select(x => new RequestModel
            {
                Id = x.Id,
                FromCity = x.FromCity,
                ToCity = x.ToCity,
                DepartureDateTime = x.DepartureDateTime,
                Fare = x.Fare,
                Status = x.Status,
                UserId = x.UserId
            }).ToList();
            return searchRequests;
        }
        public void Add(RequestModel model)
        {
            _DBcontext.Add(new Request { 
                Id=model.Id,
                FromCity=model.FromCity,
                ToCity=model.ToCity,
                DepartureDateTime=model.DepartureDateTime,
                Fare = model.Fare,
                Status = model.Status,
                UserId = model.UserId
            });
        }
        public void Update(RequestModel model)
        {
            var entity = _DBcontext.Get(x => x.Id == model.Id).FirstOrDefault();
            if(entity != null)
            {
                entity.FromCity = model.FromCity;
                entity.ToCity = model.ToCity;
                entity.DepartureDateTime = model.DepartureDateTime;
                entity.Fare = model.Fare;
                entity.Status = model.Status;
                entity.UserId = model.UserId;
            }
        }
        public void Delete(int id)
        {
            var request = _DBcontext.Get(x=>x.Id==id).FirstOrDefault();
            if(request != null)
            {
                _DBcontext.Delete(request);
            }
        }
    }
}