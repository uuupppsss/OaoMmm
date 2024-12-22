using OaoMmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Controllers
{
    public class UserController
    {
        public List<RepairRequest> Requests { get; set; }
        private List<Status> statuses;
        private List<Priority> priorities;

        public UserController()
        {
            statuses = new List<Status>()
            {
                new Status { Id = 1, Name = "Создан" },
                new Status { Id = 2, Name = "Принят" },
                new Status { Id = 3, Name = "Завершен" }
            };

            priorities = new List<Priority>
            {
                new Priority { Id = 1, Name = "Низкий" },
                new Priority { Id = 2, Name = "Средний" },
                new Priority { Id = 3, Name = "Высокий" }
            };
        }
        public void CreateNewRequest(RepairRequest request)
        {
            Requests.Add(request);
        }

        public List<RepairRequest> ShowMyActiveRequests(int user_id)
        {
            return Requests.Where(r=>r.UserId==user_id&&r.StatusId!=3).ToList();
        }
    }
}
