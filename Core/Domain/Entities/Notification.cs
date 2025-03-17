using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
