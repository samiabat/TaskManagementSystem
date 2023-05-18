using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.Handlers.Queries;
using TaskManagement.Application.Features.Tasks.Requests.Queries;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Queries;
using TaskManagement.Application.Features.Users.Requests.Queries;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagment.Application.Features.Tasks.DTO;
using Xunit;

namespace TaskManagement.UnitTest.Task.Queries
{
    public class GetTaskListQueryTest
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private IMapper _mapper;

        public GetTaskListQueryTest()
        {
            _mockRepo = MockTaskRepository.GetTaskRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async System.Threading.Tasks.Task GetTaskListTest()
        {
            var handler = new GetTaskListQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetTaskListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TaskDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}