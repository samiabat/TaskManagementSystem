using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.DTOs;
using TaskManagement.Application.Features.Checklists.Handlers.Commands;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagment.Application.Features.Checklists.DTOs;
using Xunit;

namespace TaskManagement.UnitTest.Checklist.Commands
{
    public class CreateChecklistCommandTest
    {
        private readonly Mock<IChecklistRepository> _mockRepo;
        private IMapper _mapper;

        private CreateChecklistDTO _checklistDTO;


        public CreateChecklistCommandTest() { 
            _mockRepo = MockChecklistRepository.GetChecklistRepository();

            var task = new _Task { Id=1, Description= "Descripiotn", Title = "Date" };
            _checklistDTO = new ()
            {
                Id = 3,
                Email = "abebe@gmail.com",
                FullName = "Abebe Kebede",
                Password = "password",
                Task = task
            };

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async System.Threading.Tasks.Task CanCreateChecklistValid()
        {
            var handler = new CreateChecklistCommandHandler(_mockRepo.Object, _mapper);
            await handler.Handle(new CreateCheckListCommand { checklistDTO = _checklistDTO }, CancellationToken.None);
            var checklists = await _mockRepo.Object.GetAll();
            checklists.Count.ShouldBe(3);
        }
    }
}
