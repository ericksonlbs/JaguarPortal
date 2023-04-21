using AutoMapper;
using JaguarPortal.Core.Models;
using JaguarPortal.WebApi.Models.Request;
using JaguarPortal.WebApi.Models.Response;

namespace JaguarPortal.WebApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Profile to mapping models core to models webapi or models webapi to models core
        /// </summary>
        public MappingProfile()
        {
            #region project
            CreateMap<Project, ProjectResponse>();
            CreateMap<ProjectUpdateRequest, Project>();
            CreateMap<ProjectInsertRequest, Project>();
            #endregion

            #region user
            CreateMap<User, UserResponse>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<UserInsertRequest, User>();
            #endregion

            #region user
            CreateMap<Analysis, AnalysisResponse>();
            CreateMap<Spectrum, SpectrumResponse>();
            CreateMap<AnalysisInsertRequest, Analysis>();
            CreateMap<SpectrumInsertRequest, Spectrum>();
            #endregion

            #region authentication
            CreateMap<Token, UserAuthenticationResponse>();
            #endregion
        }
    }
}