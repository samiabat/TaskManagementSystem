using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Queries;
using TaskManagement.Application.Features.Users.Requests.Queries;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.User.Queries
{
    public class GetUserListQueryTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;

        public GetUserListQueryTest()
        {
            _mockRepo = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async System.Threading.Tasks.Task GetUserListTest()
        {
            var handler = new GetUserListQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetUserListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<UserDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}

