using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.Handlers.Queries;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Task.Queries
{
    public class GetTaskDetailQueryTest
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private IMapper _mapper;
        public GetTaskDetailQueryTest() {
            _mockRepo = MockTaskRepository.GetTaskRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();

            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async System.Threading.Tasks.Task getTaskDetailTestValid ()
        {
            int id = 2;
            var handler = new GetTaskDetailQueryHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new Application.Features.Tasks.Requests.Queries.GetTaskDetailQuery { Id = id }, CancellationToken.None);
            result.ShouldNotBeNull();
        }
        [Fact]
        public async System.Threading.Tasks.Task getTaskDetailTestInvalid()
        {
            int id = 5;
            var handler = new GetTaskDetailQueryHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new Application.Features.Tasks.Requests.Queries.GetTaskDetailQuery { Id = id }, CancellationToken.None);
            result.ShouldBeNull();
        }
    }
}
