using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Model
{
    public class Equipment
    {
        public int Id { get; set; } // Идентификатор оборудования
        public string Model { get; set; } // Модель оборудования
        public int TypeId { get; set; } // Идентификатор типа оборудования
    }
}
