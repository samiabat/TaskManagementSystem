using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagement.Application.Profiles;
using Xunit;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Handlers.Commands;
using TaskManagement.Application.Features.Users.Requests.Commands;
using Shouldly;
using MediatR;

namespace TaskManagement.UnitTest.User.Commands
{
    public class CreateUserCommandTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        private CreateUserDTO _userDto;

        public CreateUserCommandTest()
        {
            _mockRepo = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _userDto = new CreateUserDTO
            {
                AccountId = "6",
                Email = "sami@gmail.com",
                Password = "password",
                FullName = "Samuel",
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateUserTestValid()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new CreateUserCommand { userDTO = _userDto }, CancellationToken.None);

            var users = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<Unit>();
            users.Count.ShouldBe(3);
        }
        [Fact]
        public async System.Threading.Tasks.Task CreateUserTestInvalid()
        {
            /* var userDto = new CreateUserDTO
            {
                Id = 6,
                Password = "password",
                FullName = "Samuel",
            };

            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new CreateUserCommand { userDTO = userDto }, CancellationToken.None);

            var users = await _mockRepo.Object.GetAll();
            var exist = await _mockRepo.Object.Exists(userDto.Id);
            exist.ShouldBeFalse();
            users.Count.ShouldBe(2);
            */
        }


    }
}

