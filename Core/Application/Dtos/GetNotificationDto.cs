using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class GetNotificationDto
    {
        public string Id {  get; set; }
        public string Title {  get; set; }
        public string Message {  get; set; }
    }
}
