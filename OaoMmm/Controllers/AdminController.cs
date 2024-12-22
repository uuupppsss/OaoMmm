using OaoMmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Controllers
{
    public class AdminController
    {
        public List<RepairRequest> Requests { get; set; }

        private List<Status> statuses;
        private List<Priority> priorities;

        public AdminController()
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


        public List<RepairRequest> ShowRequests(int? priority=null, int? status = null, DateTime? reciept_date=null )
        {
            List<RepairRequest> result = [..Requests];
            if ( status != null )
                result = result.Where(e => e.StatusId == status).ToList();
            if (priority != null)
                result = result.Where(e => e.PriorityId == priority).ToList();
            if (reciept_date != null)
                result = result.Where(e => e.DateOfReceipt == reciept_date).ToList();
            return result;
        }

        public List<RepairRequest> ShowAcceptedRequests(int admin_id)
        {
            return Requests.Where(r=>r.ExecutorId==admin_id&&r.StatusId==2).ToList();
        }

        public void AcceptRequest(int request_id, int admin_id)
        {
            var found_request = Requests.FirstOrDefault(r => r.Id == request_id);
            found_request.ExecutorId = admin_id;
        }

        public void ChangeRequestStatus(int request_id, int status_id)
        {
            var found_request = Requests.FirstOrDefault(r => r.Id == request_id);
            found_request.StatusId = status_id;
        }
    }
}
