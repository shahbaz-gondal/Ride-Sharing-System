using RSS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RideSharingDbContext _context;
        public IOfferRepository offers { get; }

        public IRequestRepository requests { get; }

        public IUserRepository users { get; }
        public UnitOfWork(RideSharingDbContext context, IOfferRepository _offer, IRequestRepository _request, IUserRepository _user)
        {
            _context = context;
            offers = _offer;
            requests = _request;
            users = _user;
        }
        

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
