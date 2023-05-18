using AutoMapper;
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
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Task.Commands
{
    public class CreateTaskCommandTest
    {
        private Mock<ITaskRepository> _mockRepo;
        private IMapper _mapper;

        private CreateTaskDTO _taskDTO;

        public CreateTaskCommandTest() {
            var user = new TaskManagemnt.Domain.User
            {
                Id = 4,
                Password = "1234",
                Email = "kebe@gmail.com",
                FullName = "Kebe abe",
            };

            _taskDTO = new CreateTaskDTO
            {
                Id = 3,
                StartDate = DateTime.Now,
                Owner = user,
                Title = "Title",
                Description = "Description",
                Status = false
            };

            _mockRepo = MockTaskRepository.GetTaskRepository();
            var mappingConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            _mapper = new Mapper(mappingConfig);
        }

        [Fact]
        public async System.Threading.Tasks.Task createTaskValid()
        {
            var handler = new CreateTaskCommandHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new CreateTaskCommand { taskDTO = _taskDTO }, CancellationToken.None);
            var tasks = await _mockRepo.Object.GetAll();
            tasks.Count.ShouldBe(3);

        }
    }
}
