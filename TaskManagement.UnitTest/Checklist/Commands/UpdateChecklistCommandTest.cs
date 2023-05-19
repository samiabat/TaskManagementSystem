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
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Checklist.Commands
{
    public class UpdateChecklistCommandTest
    {
        private readonly Mock<IChecklistRepository> _mockRepo;
        private IMapper _mapper;
        private UpdateChecklistDTO _checklistDTO;

        public UpdateChecklistCommandTest()
        {
            _mockRepo = MockChecklistRepository.GetChecklistRepository();

            _checklistDTO = new UpdateChecklistDTO
            {
                Id = 1,
                Description = "Test",
                TaskId = 1,
            };
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task updateChecklistValid()
        {
            var handler = new UpdateChecklistCommandHandler(_mockRepo.Object, _mapper);
            var result = handler.Handle(new UpdateChecklistCommand { checklistDTO = _checklistDTO }, CancellationToken.None);
            var checklist = await _mockRepo.Object.Get(_checklistDTO.Id);
            checklist.Description.ShouldBe("Test");

            
        }
        [Fact]
        public async System.Threading.Tasks.Task updateChecklistInvalid()
        {
            var invalidDto = new UpdateChecklistDTO
            {
                Id = 100,
                Description = "Test",
                TaskId = 1,
            };
            var handler = new UpdateChecklistCommandHandler(_mockRepo.Object, _mapper);
            try
            {
                var result = handler.Handle(new UpdateChecklistCommand { checklistDTO = invalidDto }, CancellationToken.None);
            }
            catch (Exception ex) {
            }
            
            var checklist = await _mockRepo.Object.Get(_checklistDTO.Id);
            checklist.Description.ShouldNotBe("Test");


        }
    }
}
