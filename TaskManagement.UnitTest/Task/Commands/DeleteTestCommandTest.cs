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
    public class DeleteTestCommandTest
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private IMapper _mapper;
        private DeleteTaskDTO _taskDTO;

        public DeleteTestCommandTest()
        {
            _mockRepo = MockTaskRepository.GetTaskRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _taskDTO = new DeleteTaskDTO
            {
                Id = 2
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteeTaskTestValid()
        {
            var handler = new DeleteTaskCommandHandler(_mockRepo.Object, _mapper);


            var result = await handler.Handle(new DeleteTaskCommand { Id = _taskDTO.Id }, CancellationToken.None);
            
            var users = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<Unit>();
            users.Count.ShouldBe(1);
        }
        [Fact]
        public async System.Threading.Tasks.Task DeleteTaskInvalid()
        {
            var handler = new DeleteTaskCommandHandler(_mockRepo.Object, _mapper);
            try
            {
                var result = await handler.Handle(new DeleteTaskCommand { Id = 100 }, CancellationToken.None);
            }
            catch (Exception ex)
            {
                //
            }

            var users = await _mockRepo.Object.GetAll();
            users.Count.ShouldBe(2);
        }

    }
}

