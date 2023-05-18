using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain.Common;

namespace TaskManagemnt.Domain
{
    public class Checklist: BaseDomainEntity
    {
        public _Task Task { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
