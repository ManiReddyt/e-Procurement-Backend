using AutoMapper;
using EProcurement.Applications.DTO;
using EProcurement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurment.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<BuyerRegisterRequestDTO, BuyerRegistrationRequest>().ReverseMap();
            CreateMap<Tender, TenderDTO>().ReverseMap();
            CreateMap<RecommendationsAndBidsDTO, BidAndPrediction>().ReverseMap();
        }
    }
}
