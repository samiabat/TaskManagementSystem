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
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Queries;
using TaskManagement.Application.Features.Users.Requests.Queries;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagment.Application.Features.Checklists.DTOs;
using Xunit;

namespace TaskManagement.UnitTest.Checklist.Queries
{
    public class GetChecklistListQueryTest
    {
        private readonly Mock<IChecklistRepository> _mockRepo;
        private IMapper _mapper;

        public GetChecklistListQueryTest()
        {
            _mockRepo = MockChecklistRepository.GetChecklistRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async System.Threading.Tasks.Task GetChecklistListTest()
        {
            var handler = new GetChecklistListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetChecklistListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ChecklistDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}