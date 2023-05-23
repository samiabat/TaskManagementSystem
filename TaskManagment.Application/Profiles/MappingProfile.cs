using AutoMapper;
using TaskManagement.Application.Features.Checklists.DTOs;
using TaskManagement.Application.Features.Tasks.DTO;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagemnt.Domain;
using TaskManagment.Application.Features.Checklists.DTOs;
using TaskManagment.Application.Features.Tasks.DTO;
using TaskManagment.Application.Features.Users.DTOs;
using TaskManagment.Application.Models.Identity;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, DeleteUserDTO>().ReverseMap();
            CreateMap<RegisterDTO, CreateUserDTO>().ReverseMap();
            CreateMap<RegisterDTO, RegisterModel>().ReverseMap();

            CreateMap<_Task, CreateTaskDTO>().ReverseMap();
            CreateMap<_Task, UpdateTaskDTO>().ReverseMap();
            CreateMap<_Task, DeleteTaskDTO>().ReverseMap();
            CreateMap<_Task, TaskDTO>().ReverseMap();

            CreateMap<Checklist, CreateChecklistDTO>().ReverseMap();
            CreateMap<Checklist, UpdateChecklistDTO>().ReverseMap();
            CreateMap<Checklist, DeleteChecklistDto>().ReverseMap();
            CreateMap<Checklist, ChecklistDTO>().ReverseMap();
        }

    }
}
