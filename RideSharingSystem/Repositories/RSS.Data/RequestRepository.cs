using RSS.Data.Interfaces;
using RSS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data
{
    public class RequestRepository:Repository<Request>, IRequestRepository
    {
        public RequestRepository(RideSharingDbContext context):base(context)
        {
        }
    }
}
