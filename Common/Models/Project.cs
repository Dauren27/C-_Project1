using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public Employee ProjectManager { get; set; }
    }
}
