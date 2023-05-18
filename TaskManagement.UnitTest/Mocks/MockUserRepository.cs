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
    public class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<TaskManagemnt.Domain.User>{
            new (){
                Id=4,
                Password = "1234",
                Email = "kebe@gmail.com",
                FullName = "Kebe abe",
            },

            new ()
            {
                Id=5,
                Password = "1234",
                Email = "ale@gmail.com",
                FullName = "ale abe",
            }
        };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(users);

            mockRepo.Setup(r => r.Add(It.IsAny<TaskManagemnt.Domain.User>())).ReturnsAsync((TaskManagemnt.Domain.User user) =>
            {
                users.Add(user);
                return user;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<TaskManagemnt.Domain.User>())).Callback((TaskManagemnt.Domain.User user) =>
            {
                var newUser = users.Where((r) => r.Id != user.Id);
                users = newUser.ToList();
                users.Add(user);
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<TaskManagemnt.Domain.User>())).Callback((TaskManagemnt.Domain.User user) =>
            {
                if (users.Exists(b => b.Id == user.Id))
                    users.Remove(users.Find(b => b.Id == user.Id)!);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var userId = users.FirstOrDefault((r) => r.Id == id);
                return userId != null;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
            {
                return users.FirstOrDefault((r) => r.Id == id);
            });
            return mockRepo;
        }
    }
}