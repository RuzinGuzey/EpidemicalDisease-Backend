using AutoMapper;
using EpidemicalDisease.Application.Dtos;
using EpidemicalDisease.Domain.Entities;

namespace EpidemicalDisease.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DiseaseAnalysis, DiseaseAnalysisDto>();
            CreateMap<MedicalCenter, MedicalCenterDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Vaccine, VaccineDto>();
            CreateMap<VaccineType, VaccineTypeDto>();
        }
    }
}
