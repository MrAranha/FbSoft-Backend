using AutoMapper;
using FbSoft_MediatrHandling.EntityRequests.Login.Result;
using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_Services.Entities;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetCarroRequest, GetCarroResult>();
            CreateMap<GetCarroResult, GetCarroRequest>();
            CreateMap<GetCarroResult, TB_Users>();
            CreateMap<TB_Users, GetCarroResult>().ReverseMap();
        }
    }
}
