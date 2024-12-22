using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Model
{
    public class RepairRequest
    {
        public int Id { get; set; } // Идентификатор заявки
        public int UserId { get; set; } // Идентификатор пользователя, создавшего заявку
        public string Place { get; set; } // Место, в котором находится оборудование
        public int EquipmentId { get; set; } // Идентификатор оборудования, которое нужно починить
        public string? Description { get; set; } // Описание проблемы (может быть null)
        public int StatusId { get; set; } // Идентификатор статуса заявки
        public DateTime DateOfReceipt { get; set; } // Дата отправки заявки
        public int PriorityId { get; set; } // Идентификатор приоритета заявки
        public int ExecutorId { get; set; } // Исполнитель работ (идентификатор пользователя)
        public DateTime? StartDate { get; set; } // Дата начала работ (может быть null)
        public DateTime? EndDate { get; set; } // Дата завершения работ (может быть null)
    }
}
