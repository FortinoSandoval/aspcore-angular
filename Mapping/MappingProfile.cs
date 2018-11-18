using aspcore_angular.Controllers.Resources;
using aspcore_angular.Models;
using AutoMapper;

namespace aspcore_angular.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Make, MakeResource>();
      CreateMap<Model, ModelResource>();
      CreateMap<Feature, FeatureResource>();

    }
  }
}