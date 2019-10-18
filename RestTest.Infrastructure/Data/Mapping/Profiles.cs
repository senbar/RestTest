using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RestTest.Infrastructure.Data.Mapping
{
    public class DataProfiles  : Profile
    {
        public DataProfiles()
        {
            CreateMap<RestTest.Core.Domain.Entities.Company, Entities.Company>();
        }
    }
}
