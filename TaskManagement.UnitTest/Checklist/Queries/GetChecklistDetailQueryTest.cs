using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.Handlers.Queries;
using TaskManagement.Application.Features.Checklists.Requests.Queries;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Checklist.Queries
{
    public class GetChecklistDetailQueryTest
    {
        private readonly Mock<IChecklistRepository> _mockRepo;

        private IMapper _mapper;


        public GetChecklistDetailQueryTest() { 
            _mockRepo = MockChecklistRepository.GetChecklistRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task getChecklistDetailValid () {
            var handler = new GetChecklistDetailQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetChecklistDetailQuery { Id = 1 }, CancellationToken.None);
            result.ShouldNotBeNull();
        }

    }
}
