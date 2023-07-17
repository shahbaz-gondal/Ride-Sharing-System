using AutoMapper;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class RequestService:IRequestService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public RequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<RequestModel> GetAll()
        {
            var allRequestsList = _UnitOfWork.requests.GetAll();
            var RequestsList = _mapper.Map<List<RequestModel>>(allRequestsList);
            return RequestsList;
        }
        public List<RequestModel> myRequests(int userId)
        {
            var myAllRequests = _UnitOfWork.requests.Get(x => x.UserId == userId).ToList();
            var MyRequests = _mapper.Map<List<RequestModel>>(myAllRequests);
            return MyRequests;
        }
        public List<RequestModel> SearchRequest(string fromCity, string toCity)
        {
            fromCity = fromCity.Trim().ToLower();
            toCity = toCity.Trim().ToLower();

            var allRequests = _UnitOfWork.requests.Get(x => x.FromCity.ToLower().Contains(fromCity)
            && x.ToCity.ToLower().Contains(toCity)).ToList();

            var searchRequests = _mapper.Map<List<RequestModel>>(allRequests);
            return searchRequests;
        }
        public void Add(RequestModel model)
        {
            var entity = _mapper.Map<Request>(model);
            _UnitOfWork.requests.Add(entity);
            _UnitOfWork.Save();
        }
        public void Update(RequestModel model)
        {
            var entity = _mapper.Map<Request>(model);
            _UnitOfWork.requests.Update(entity);
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