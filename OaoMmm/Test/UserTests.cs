using OaoMmm.Controllers;
using OaoMmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Test
{
    public class UserTests
    {
        UserController controller;
        [SetUp]
        public void Setup()
        {
            controller = new UserController();
            controller.Requests = new List<RepairRequest>
            {
                new RepairRequest
                {
                    Id = 1,
                    UserId = 101,
                    Place = "Офис 1",
                    EquipmentId = 1001,
                    Description = "Не работает принтер.",
                    StatusId = 1,
                    DateOfReceipt = DateTime.Now,
                    PriorityId = 2,
                    ExecutorId = 201,
                    StartDate = null,
                    EndDate = null
                },
                new RepairRequest
                {
                    Id = 2,
                    UserId = 102,
                    Place = "Офис 2",
                    EquipmentId = 1002,
                    Description = "Сломался проектор.",
                    StatusId = 1,
                    DateOfReceipt = DateTime.Now,
                    PriorityId = 1,
                    ExecutorId = 202,
                    StartDate = null,
                    EndDate = null
                }
            };
        }

        [Test]
        public void CreateNewRequestTest()
        {
            var request = new RepairRequest
            {
                Id = 3,
                UserId = 102,
                Place = "Офис 3",
                EquipmentId = 1002,
                Description = "Сломался проектор.",
                StatusId = 1,
                DateOfReceipt = DateTime.Now,
                PriorityId = 1,
                ExecutorId = 202,
                StartDate = null,
                EndDate = null
            };
            controller.CreateNewRequest(request);
            Assert.IsTrue(controller.Requests.Contains(request));
        }

        [Test]
        public void ShowMyActiveRequests()
        {
            var requests = controller.ShowMyActiveRequests(101);
            var expected_collection= 
                controller.Requests.Where(r => r.UserId == 101 && r.StatusId != 3).ToList();
            Assert.AreEqual(requests, expected_collection);
        }
    }
}
