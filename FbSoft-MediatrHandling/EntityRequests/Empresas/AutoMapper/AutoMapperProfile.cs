using AutoMapper;
using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetEmpresasRequest, GetEmpresasResult>();
            CreateMap<GetEmpresasResult, GetEmpresasRequest>();
            CreateMap<GetEmpresasResult, TB_Empresas>();
            CreateMap<TB_Empresas, GetEmpresasResult>().ReverseMap();
        }
    }
}
