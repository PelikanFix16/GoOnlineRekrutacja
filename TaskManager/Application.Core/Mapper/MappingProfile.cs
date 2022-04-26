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
    /// <summary>
    /// Base mapping profile for automapper
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskModel,TaskModelOutput>();
            CreateMap<TaskModelInput, TaskModel>();

        }
    }
}
