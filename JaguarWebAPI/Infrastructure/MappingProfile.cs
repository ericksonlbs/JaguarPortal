using AutoMapper;
using JaguarWebAPI.Models;

namespace JaguarWebAPI.Infrastructure
{
 public class MappingProfile : Profile {
     public MappingProfile() {
         // Add as many of these lines as you need to map your objects
         CreateMap<AnalysisControlFlowModel, AnalysisControlFlowNewModel>();
         CreateMap<AnalysisControlFlowNewModel, AnalysisControlFlowModel>();
     }
 }
}