using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RestTest.Core;
using RestTest.Core.Domain.Enums;

namespace RestTest.Infrastructure.Data.Mapping
{
    public class DataProfiles  : Profile
    {
        public class JobTitleConverter : ITypeConverter<JobTitles, int>
        {
            public int Convert(JobTitles source, int destination, ResolutionContext context)
            {
                return (int)source;
            }
        }

        public DataProfiles()
        {
            CreateMap<Entities.Employee, Core.Domain.Entities.Employee>()
                .ForMember(dest => dest.JobTitle,
                opt => opt.MapFrom(src => (JobTitles)src.JobTitle));

            CreateMap<Entities.Employee, Core.Domain.Entities.Employee>()
                .ForMember(dest => dest.JobTitle,
                opt => opt.MapFrom(src => (int)src.JobTitle));
                
            CreateMap<RestTest.Core.Domain.Entities.Company, Entities.Company>()
               .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
        }
    }
}
