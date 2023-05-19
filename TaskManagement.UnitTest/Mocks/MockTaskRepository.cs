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
    public class MockTaskRepository
    {
        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var user = new TaskManagemnt.Domain.User
            {
                Id = 4,
                Password = "1234",
                Email = "kebe@gmail.com",
                FullName = "Kebe abe",
            };
            var tasks = new List<_Task>{
            new (){
                Id = 1,
                StartDate = DateTime.Now,
                Owner = user,
                Title = "Title",
                Description = "Description",
                Status = false
            },

            new ()
            {
                Id = 2,
                StartDate = DateTime.Now,
                Owner = user,
                Title = "Title",
                Description = "Description",
                Status = false
            }
        };

            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(tasks);

            mockRepo.Setup(r => r.Add(It.IsAny<_Task>())).ReturnsAsync((_Task task) =>
            {
                tasks.Add(task);
                return task;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<_Task>())).Callback((_Task task) =>
            {
                var newTask = tasks.Where((r) => r.Id != task.Id);
                tasks = newTask.ToList();
                tasks.Add(task);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<_Task>())).Callback((_Task task) =>
            {
                if (tasks.Exists(b => b.Id == task.Id))
                    tasks.Remove(tasks.Find(b => b.Id == task.Id)!);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var taskId = tasks.FirstOrDefault((r) => r.Id == id);
                return taskId != null;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
            {
                return tasks.FirstOrDefault((r) => r.Id == id);
            });
            return mockRepo;
        }
    }
}