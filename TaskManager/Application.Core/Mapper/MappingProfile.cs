using AutoMapper;
using Domain.Core;
using Service.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskModel,TaskModelOutput>();
            CreateMap<TaskModelInput, TaskModel>();

        }
    }
}
