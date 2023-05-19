using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.DTO;
using TaskManagement.Application.Features.Tasks.Handlers.Commands;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Commands;
using TaskManagement.Application.Features.Users.Requests.Commands;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Task.Commands
{
    public class UpdateTaskCommandTest
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private IMapper _mapper;
        private UpdateTaskDTO _taskDTO;

        public UpdateTaskCommandTest()
        {
            _mockRepo = MockTaskRepository.GetTaskRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _taskDTO = new UpdateTaskDTO
            {
                Id = 2,
                Email = "sami@gmail.com",
                Password = "password",
                FullName = "Samuel",
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateUserTest()
        {
            var handler = new UpdateTaskCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateTaskCommand { taskDTO = _taskDTO }, CancellationToken.None);

            var users = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<Unit>();
            users.Count.ShouldBe(2);
        }

    }
}

