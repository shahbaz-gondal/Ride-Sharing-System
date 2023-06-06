using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class RequestService:IRequestService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public RequestService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public List<RequestModel> GetAll()
        {
            var allRequestsList = _UnitOfWork.requests.GetAll();
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
            var myAllRequests = _UnitOfWork.requests.Get(x => x.UserId == userId).ToList();
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
            var allRequests = _UnitOfWork.requests.Get(x => x.FromCity.ToLower().Contains(fromCity)
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
            _UnitOfWork.requests.Add(new Request { 
                Id=model.Id,
                FromCity=model.FromCity,
                ToCity=model.ToCity,
                DepartureDateTime=model.DepartureDateTime,
                Fare = model.Fare,
                Status = model.Status,
                UserId = model.UserId
            });
            _UnitOfWork.Save();
        }
        public void Update(RequestModel model)
        {
            _UnitOfWork.requests.Update(new Request
            {
                Id = model.Id,
                FromCity = model.FromCity,
                ToCity = model.ToCity,
                DepartureDateTime = model.DepartureDateTime,
                Fare = model.Fare,
                Status = model.Status,
                UserId = model.UserId
            });
            _UnitOfWork.Save();
        }
        public void Delete(int id)
        {
            var request = _UnitOfWork.requests.Get(x=>x.Id==id).FirstOrDefault();
            if(request != null)
            {
                _UnitOfWork.requests.Delete(request);
                _UnitOfWork.Save();
            }
        }
    }
}