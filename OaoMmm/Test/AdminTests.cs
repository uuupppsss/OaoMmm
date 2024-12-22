using OaoMmm.Controllers;
using OaoMmm.Model;

namespace OaoMmm.Test
{
    public class AdminTests
    {
        AdminController controller;
        [SetUp]
        public void Setup()
        {
            controller = new AdminController();
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
        public void ShowRequests_Test()
        {
            var requests= controller.ShowRequests();
            Assert.AreEqual( requests, controller.Requests);
        }

        [Test]
        public void ShowFilterRequests_Test()
        {
            var requests = controller.ShowRequests(1);
            var expected_collection= controller.Requests.Where(e => e.PriorityId == 1).ToList();
            Assert.AreEqual(requests, expected_collection);
        }

        [Test]
        public void ShowAcceptedRequestsTest() 
        {
            var expected_collection= 
                controller.Requests.Where(r => r.ExecutorId == 201 && r.StatusId == 2).ToList();
            var requests=controller.ShowAcceptedRequests(201);
            Assert.AreEqual(requests, expected_collection);
        }

        [Test]
        public void AcceptRequestTest()
        {
            controller.AcceptRequest(1, 1);
            var request = controller.Requests.FirstOrDefault(r => r.Id == 1);
            Assert.AreEqual(request.ExecutorId, 1);
        }

        [Test]
        public void ChangeRequestStatusTest()
        {
            controller.ChangeRequestStatus(1, 3);
            var request = controller.Requests.FirstOrDefault(r => r.Id == 1);
            Assert.AreEqual(request.StatusId, 3);
        }
    }
}