using AutoMapper;
using JaguarPortal.Web.Models.Account;
using JaguarPortal.WebApi.Models.Request;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<RegisterVM, UserInsertRequest>();
        CreateMap<RegisterVM, UserInsertRequest>();
        CreateMap<LoginVM, UserAuthenticationRequest>();
    }
}