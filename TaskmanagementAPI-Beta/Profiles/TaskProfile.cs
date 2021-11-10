using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Models.Task, TaskReadDto>();                

            CreateMap<TaskCreateDto, Models.Task>() ;

            CreateMap<Status, StatusReadDto>();

            CreateMap<User, UserReadDto>();

            CreateMap<UserCreateDto, User>();
        }
    }
}
