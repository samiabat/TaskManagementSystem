using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.Handlers.Commands;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagement.Application.Profiles;
using TaskManagement.UnitTest.Mocks;
using TaskManagment.Application.Contracts.Persistence;
using Xunit;

namespace TaskManagement.UnitTest.Checklist.Commands
{
    public class DeleteChecklistCommandTest
    {
        private readonly Mock<IChecklistRepository> _mockRepo;
        private IMapper _mapper;

        public DeleteChecklistCommandTest() {
            _mockRepo = MockChecklistRepository.GetChecklistRepository();
            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task deleteChecklistValid()
        {
            var handler = new DeleteChecklistCommandHandler(_mockRepo.Object, _mapper);
            await handler.Handle(new DeleteChecklistCommand { Id = 1 }, CancellationToken.None);
            var checklists = await _mockRepo.Object.GetAll();
            checklists.Count.ShouldBe(1);

        }
        [Fact]
        public async System.Threading.Tasks.Task deleteChecklistInvalid()
        {
            var handler = new DeleteChecklistCommandHandler(_mockRepo.Object, _mapper);
            try
            {
                await handler.Handle(new DeleteChecklistCommand { Id = 100 }, CancellationToken.None);
            } 
            catch (Exception ex)
            {
                // 
            }
            
            var checklists = await _mockRepo.Object.GetAll();
            checklists.Count.ShouldBe(2);

        }
    }
}
