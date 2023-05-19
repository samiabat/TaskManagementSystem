using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.UnitTest.Mocks
{
    public class MockChecklistRepository
    {
        public static Mock<IChecklistRepository> GetChecklistRepository()
        {
            var user = new TaskManagemnt.Domain.User
            {
                Id = 4,
                Password = "1234",
                Email = "kebe@gmail.com",
                FullName = "Kebe abe",
            };
            var task = new _Task {
                Id = 2,
                StartDate = DateTime.Now,
                Owner = user,
                Title = "Title",
                Description = "Description",
                Status = false
            };
            var checklists = new List<TaskManagemnt.Domain.Checklist>{
                new () { 
                    Id = 1,
                    Description = "Description",
                    Status = false,
                    Task = task,
                    TaskId = 2,
                },
                new () {
                    Id = 2,
                    Description = "Description",
                    Status = false,
                    Task = task,
                    TaskId = 2,
                }
        };

            var mockRepo = new Mock<IChecklistRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(checklists);

            mockRepo.Setup(r => r.Add(It.IsAny<TaskManagemnt.Domain.Checklist>())).ReturnsAsync((TaskManagemnt.Domain.Checklist checklist) =>
            {
                checklists.Add(checklist);
                return checklist;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<TaskManagemnt.Domain.Checklist>())).Callback((TaskManagemnt.Domain.Checklist checklist) =>
            {
                var  newChecklist = checklists.Where((r) => r.Id != checklist.Id);
                checklists = newChecklist.ToList();
                checklists.Add(checklist);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<TaskManagemnt.Domain.Checklist>())).Callback((TaskManagemnt.Domain.Checklist checklist) =>
            {
                if (checklists.Exists(b => b.Id == checklist.Id))
                    checklists.Remove(checklists.Find(b => b.Id == checklist.Id)!);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var checlistId = checklists.FirstOrDefault((r) => r.Id == id);
                return checlistId != null;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
            {
                return checklists.FirstOrDefault((r) => r.Id == id);
            });
            return mockRepo;
        }
    }
}