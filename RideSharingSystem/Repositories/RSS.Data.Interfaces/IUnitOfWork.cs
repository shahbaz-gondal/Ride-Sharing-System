using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IOfferRepository offers { get; }
        public IRequestRepository requests { get; }
        public IUserRepository users { get; }

        public int Save();
    }
}
