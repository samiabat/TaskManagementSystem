using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Commands;
using TaskManagement.Application.Features.Users.Requests.Commands;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.User.Commands
{
    public class UpdateUserCommandTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        private UpdateUserDTO _userDto;

        public UpdateUserCommandTest()
        {
            _mockRepo = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _userDto = new UpdateUserDTO
            {
                Id = 4,
                Email = "sami@gmail.com",
                Password = "password",
                FullName = "Samuel",
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateUserTest()
        {
            var handler = new UpdateUserCommandHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new UpdateUserCommand { userDTO = _userDto }, CancellationToken.None);

            var users = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<Unit>();
            users.Count.ShouldBe(2);
        }

    }
}

