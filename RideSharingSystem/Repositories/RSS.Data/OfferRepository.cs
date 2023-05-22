using RSS.Data.Interfaces;
using RSS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(RideSharingDbContext context):base(context)
        {
        }
    }
}
