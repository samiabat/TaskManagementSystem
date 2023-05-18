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
    public class GetUserDetailQueryTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        public GetUserDetailQueryTest() { 
            _mockRepo = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task getUserDetailValid()
        {
            var Id = 4;
            var handler = new GetUserDetailQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetUserDetailQuery { Id = Id }, CancellationToken.None);
            result.ShouldBeOfType<UserDTO>();
            result.Id.ShouldBe(Id);

        }
        [Fact]
        public async System.Threading.Tasks.Task getUserDetailInvalid()
        {
            var Id = 10;
            var handler = new GetUserDetailQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetUserDetailQuery { Id = Id }, CancellationToken.None);
            result.ShouldNotBeOfType<UserDTO>();
            result.ShouldBeNull();

        }
    }
}
