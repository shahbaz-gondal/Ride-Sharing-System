using AutoMapper;
using RSS.Business.Models;
using RSS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Business.DataServices
{
    public class BusinessEntityMappings:Profile
    {
        public BusinessEntityMappings()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<OfferModel, Offer>().ReverseMap();
            CreateMap<RequestModel, Request>().ReverseMap();
        }
    }
}
